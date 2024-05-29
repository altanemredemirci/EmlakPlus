using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakPlus.WEBUI.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IStatisticService _statisticService;
        private readonly ITodoListService _todoListService;

        public SignalRHub(IStatisticService statisticService, ITodoListService todoListService)
        {
            _statisticService = statisticService;
            _todoListService = todoListService;
        }

        public async Task SendProductTypeCount()
        {
            var productTypeCount = _statisticService.ProductTypeCount();

            await Clients.All.SendAsync("ReceiveProductTypeCount", productTypeCount);
        }

        public async Task SendTodoList()
        {
            var todoList = _todoListService.GetAll();

            await Clients.All.SendAsync("ReceiveTodoList", todoList);
        }
    }
}
