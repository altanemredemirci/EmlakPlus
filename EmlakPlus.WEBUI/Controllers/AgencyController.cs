using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.DAL.Abstract;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
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


        public IActionResult Create()
        {
            return View(new CreateAgencyDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAgencyDTO dto, IFormFile file)
        {
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {

                var agency = _agencyService.GetOne(i => i.Name == dto.Name);

                if (agency!=null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 101,
                        Title = "Kayıt Hatası",
                        Description = "Aynı isimde kayıtlı bir acenta vardır. Lütfen farklı isim girişi yapınız.",
                        ReturnUrl = "/Agency/Index",
                        Css = "text-warning"
                    };
                    return View("Error", error);
                }
                if (file == null)
                {
                    ModelState.AddModelError("", "Ikon için dosya yüklenmedi.");
                    return View(dto);
                }

                dto.ImageUrl = await ImageMethods.UploadImage(file);
                _agencyService.Create(_mapper.Map<Agency>(dto));

                return RedirectToAction("Index");
            }
            return View(dto);
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
