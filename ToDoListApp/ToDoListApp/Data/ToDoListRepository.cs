using Dapper;
using ToDoListApp.Data.Models;
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

        public async Task<IEnumerable<TaskWithCategory>> GetToDoList()
        {
            var query = "SELECT t.id as Id, title as Title, description as Description, create_date as CreatedDate, " +
                "due_date as DueDate, status as Status, categories.name as Category FROM tasks t INNER JOIN categories ON t.category_id = categories.id";
            using (var connection = _context.CreateConnection())
            {
                var tasks = await connection.QueryAsync<TaskWithCategory>(query);
                return tasks.ToList();
            }
        }
    }
}
