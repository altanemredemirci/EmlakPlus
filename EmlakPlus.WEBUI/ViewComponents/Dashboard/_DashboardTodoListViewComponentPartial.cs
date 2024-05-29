using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.TodoListDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardTodoListViewComponentPartial:ViewComponent
    {
        private readonly ITodoListService _todoListService;
        private readonly IMapper _mapper;

        public _DashboardTodoListViewComponentPartial(ITodoListService todoListService, IMapper mapper)
        {
            _todoListService = todoListService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var todoLists = _mapper.Map<List<ResultTodoListDTO>>(_todoListService.GetAll());
            return View(todoLists);
        }
    }
}
