using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using EmlakPlus.BLL.DTOs.MailDTO;
using EmlakPlus.BLL.DTOs.ProductDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.EmailServices;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Areas.Agency.Controllers
{
    [Area("Agency")]
    public class AdvertController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAgencyService _agencyService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public AdvertController(IProductService productService,IMapper mapper,IMailService mailService,IAgencyService agencyService)
        {
            _productService = productService;
            _mapper = mapper;
            _mailService = mailService;
            _agencyService = agencyService;
        }

        [Route("advert")]
        public IActionResult Index()
        {
            var models = _mapper.Map<List<ResultProductDTO>>(_productService.GetAll(i => i.AgencyId == 1 && i.Status==true ));
            return View(models);
        }

        [Route("advert/expiredProduct")]
        public IActionResult ExpiredProduct()
        {
            var models = _mapper.Map<List<ResultProductDTO>>(_productService.GetAll(i => i.AgencyId == 1 && i.Status == false));
            return View(models);
        }

        [Route("advert/Mailbox")]
        public IActionResult MailBox(int? agencyId)
        {
            if (agencyId == null)
            {
                return View(_mapper.Map<List<ResultMailDTO>>(_mailService.GetAll()));
            }
            return View(_mapper.Map<List<ResultMailDTO>>(_mailService.GetAll(i => i.AgencyId == agencyId)));
        }

        [HttpPost]
        [Route("advert/SendMail")]
        public IActionResult SendEmail(Mail mail)
        {
            string body = $"<h1>Merhaba {mail.Name};</h1><br> Bize ulaştığınız {mail.Subject} konusu hakkında cevabımız şöyledir.<br><br><p>{mail.Message}</p>";
            bool result = MailHelper.SendMail(body, mail.Email, mail.Subject);
            if (result)
            {
                ReplyChange(mail.Id);
            }
               return RedirectToAction("Index", "Mail", new { agencyId = mail.Id });
               
        }

        public void ReplyChange(int id)
        {
            var mail = _mailService.GetById(id);

            mail.Reply = mail.Reply == true ? false : true;

            _mailService.Update(mail);
        }

        [Route("advert/Profile")]
        public IActionResult Profile()
        {
            var agency = _agencyService.GetById(1);
            return View(_mapper.Map<ResultAgencyDTO>(agency));
        }

        [Route("advert/EditProfile")]
        public IActionResult EditProfile(int id)
        {
            if (id < 1)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Code = 102,
                    Title = "Acenta Bulunamadı",
                    Description = "Lütfen varolan bir acenta seçiniz.",
                    ReturnUrl = "/Agency/Index",
                    Css = "text-danger"
                };
                return View("Error", error);
            }

            var agency = _agencyService.GetById(id);

            if (agency == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Code = 102,
                    Title = "Acenta Bulunamadı",
                    Description = "Lütfen varolan bir acenta seçiniz.",
                    ReturnUrl = "/Agency/Index",
                    Css = "text-danger"
                };
                return View("Error", error);
            }
            var model = _mapper.Map<UpdateAgencyDTO>(agency);

            return View(model);
        }

        [HttpPost]
        [Route("advert/EditProfile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UpdateAgencyDTO dto, IFormFile file)
        {
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {
                var agency = _agencyService.GetById(dto.Id);

                if (agency == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 102,
                        Title = "Acenta Bulunamadı",
                        Description = "Lütfen varolan bir acenta seçiniz.",
                        ReturnUrl = "/Agency/Index",
                        Css = "text-danger"
                    };
                    return View("Error", error);
                }

                if (file != null)
                {
                    ImageMethods.DeleteImage(agency.ImageUrl);
                    dto.ImageUrl = await ImageMethods.UploadImage(file);
                }

                _agencyService.Update(_mapper.Map<EmlakPlus.Entity.Agency>(dto));
                return RedirectToAction("Profile");
            }
            return View(dto);
        }


    }
}
