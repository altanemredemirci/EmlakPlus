using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.EmailServices;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Areas.Agency.Controllers
{
    [Area("Agency")]
    public class AdvertController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public AdvertController(IProductService productService,IMapper mapper,IMailService mailService)
        {
            _productService = productService;
            _mapper = mapper;
            _mailService = mailService;
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

    }
}
