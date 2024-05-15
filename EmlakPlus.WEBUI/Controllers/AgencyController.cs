using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.DAL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public AgencyController(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var agencies = _agencyService.GetAll();

            var model = _mapper.Map<List<ResultAgencyDTO>>(agencies);

            return View(model);
        }

        public IActionResult StatusChange(int id)
        {
            var agency = _agencyService.GetById(id);

            agency.Status = agency.Status == true ? false : true;

            _agencyService.Update(agency);

            return RedirectToAction("Index");
        }
    }
}
