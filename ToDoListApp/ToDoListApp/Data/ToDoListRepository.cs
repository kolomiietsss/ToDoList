using Dapper;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly DapperContext _context;

        public ToDoListRepository(DapperContext context)
        {
            _context = context;
        }

        public bool Create(TaskToDo task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskToDo>> GetTasks()
        {
            var query = "SELECT id as Id, title as Title, create_date as CreatedDate, " +
                "due_date as DueDate, status as Status, category_id as CategoryId FROM tasks";
            using (var connection = _context.CreateConnection())
            {
                var tasks = await connection.QueryAsync<TaskToDo>(query);
                return tasks.ToList();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var query = "SELECT id as Id, name as Name FROM categories";
            using (var connection = _context.CreateConnection())
            {
                var categories = await connection.QueryAsync<Category>(query);
                return categories.ToList();
            }
        }

    }
}
