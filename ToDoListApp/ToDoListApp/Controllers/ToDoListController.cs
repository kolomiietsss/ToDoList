using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoListController : Controller
    {
        
        private readonly IToDoListRepository _toDoRepo;

        public ToDoListController(IToDoListRepository toDoRepo)
        {
            _toDoRepo = toDoRepo;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tasks = await _toDoRepo.GetTasks();
                var categories = await _toDoRepo.GetCategories();

                var viewModel = new TaskListPageViewModel
                {
                    Tasks = tasks.Select(t => new TaskViewModel
                    {
                        Id = t.Id,
                        CreatedDate = t.CreatedDate,
                        DueDate = t.DueDate,
                        Status = t.Status,
                        Title = t.Title,
                        CategoryName = categories.FirstOrDefault(c => c.Id == t.CategoryId)?.Name
                    })
                   
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


    }
}
