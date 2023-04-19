using Microsoft.AspNetCore.Mvc;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers;

public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IActionResult> GetTasks()
    {
        try
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id}", Name = "TaskById")]
    public async Task<IActionResult> GetTask(int id)
    {
        try
        {
            var task = await _taskService.GetTask(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
    
}