using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ContactDTO;
using EmlakPlus.BLL.DTOs.WhoWeAreDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService,IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var contact = _contactService.GetOne();
            return View(_mapper.Map<ResultContactDTO>(contact));
        }

        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetOne();
            return View(_mapper.Map<UpdateContactDTO>(contact));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateContactDTO dto)
        {
            if (ModelState.IsValid)
            {
                var contact = _contactService.GetOne();

                if (contact == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 404,
                        Title = "İletişim Sayfası Bulunamadı",
                        Description = "Lütfen seçtiğiniz yapıyı tekrar kontrol ediniz.",
                        ReturnUrl = "/contact/Index",
                        Css = "text-danger"
                    };
                    return View("Error", error);
                }

                _contactService.Update(_mapper.Map<Contact>(dto));
                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}
