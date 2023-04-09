using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Data;

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
                var toDoList = await _toDoRepo.GetToDoList();
                return View(toDoList);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


    }
}
