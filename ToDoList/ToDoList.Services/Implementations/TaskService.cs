using Dapper;
using ToDoList.DAL;
using ToDoList.Entities.Entity;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Implementations;

public class TaskService : ITaskService
{
    private readonly DapperContext _context;
    
    public TaskService(DapperContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<TaskEntity>> GetTasks()
    {
        var query = "SELECT id as Id, title as Title, created_date as CreatedDate," +
        "due_date as DueDate, is_completed as IsCompleted, category_id as CategoryID from tasks";
        
        using (var connection = _context.CreateConnection())
        {
            var tasks = await connection.QueryAsync<TaskEntity>(query);
            return tasks.ToList();
        }
    }

    public async Task<TaskEntity> GetTask(int id)
    {
        var query = "SELECT id as Id, title as Title, created_date as CreatedDate," +
                    "due_date as DueDate, is_completed as IsCompleted, category_id as CategoryID from tasks" +
                    "WHERE id = @id";
        
        using (var connection = _context.CreateConnection())
        {
            var task = await connection.QueryFirstOrDefaultAsync<TaskEntity>(query, new { id });
            return task;
        }
    }
}