using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class TodoListController : Controller
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        public IActionResult StatusChange(int id)
        {
            var todoList = _todoListService.GetById(id);
            todoList.Status=todoList.Status == true ? false : true;
            _todoListService.Update(todoList);
            return Json(todoList);
        }
    }
}
