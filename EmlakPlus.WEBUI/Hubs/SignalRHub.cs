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

        public SignalRHub(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task SendProductTypeCount()
        {
            var productTypeCount = _statisticService.ProductTypeCount();

            await Clients.All.SendAsync("ReceiveProductTypeCount", productTypeCount);
        }
    }
}
