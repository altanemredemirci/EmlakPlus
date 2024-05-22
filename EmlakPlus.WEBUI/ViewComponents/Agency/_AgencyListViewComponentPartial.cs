using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Agency
{
    public class _AgencyListViewComponentPartial:ViewComponent
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public _AgencyListViewComponentPartial(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var agencies = _agencyService.GetAll();

            return View(_mapper.Map<List<ResultAgencyDTO>>(agencies));
        }
    }
}
