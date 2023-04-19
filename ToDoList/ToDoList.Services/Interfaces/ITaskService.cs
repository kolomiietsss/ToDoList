using ToDoList.Entities.Entity;

namespace ToDoList.Services.Interfaces;

public interface ITaskService
{
    public Task<IEnumerable<TaskEntity>> GetTasks();

    public Task<TaskEntity> GetTask(int id);
}