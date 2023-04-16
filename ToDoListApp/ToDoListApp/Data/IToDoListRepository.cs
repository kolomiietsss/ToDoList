using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public interface IToDoListRepository
    {
        bool Create(TaskToDo task);
        Task<IEnumerable<TaskToDo>> GetTasks();
        Task<IEnumerable<Category>> GetCategories();
    }
}
