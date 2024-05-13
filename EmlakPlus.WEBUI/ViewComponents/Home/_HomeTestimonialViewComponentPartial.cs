using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.BLL.DTOs.ClientDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeTestimonialViewComponentPartial : ViewComponent
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public _HomeTestimonialViewComponentPartial(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var clients = _clientService.GetAll();
            var models = _mapper.Map<List<ResultClientDTO>>(clients);
            return View(models);
        }
    }
}
