using ToDoListApp.Data.Models;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public interface IToDoListRepository
    {
        bool Create(TaskToDo task);
        public Task<IEnumerable<TaskWithCategory>> GetToDoList();
    }
}
