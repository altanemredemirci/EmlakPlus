using EmlakPlus.BLL.Abstract;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.EmailServices;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public HomeController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            return View(id);
        }

        public IActionResult ProductList()
        {
            ViewBag.Route = "ProductList";
            return View();
        }

        public IActionResult SendEmail(Mail mail)
        {
            string body = $"<h1>Ýletiþim Bilgileri</h1><br>Ad Soyad:{mail.Name}<br>Email:{mail.Email}<br>Konu:{mail.Subject}<br>Mesaj:{mail.Message}";
            bool result = MailHelper.SendMail(body, "altanemre198965@gmail.com", mail.Subject);
            if (result)
            {
                ViewBag.MailSuccess = true;
            }
            else
            {
                ViewBag.MailSuccess = false;
            }
            return View("Contact");
        }
    }
}
