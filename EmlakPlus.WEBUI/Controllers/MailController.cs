using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.MailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public MailController(IMailService mailService, IMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<ResultMailDTO>>(_mailService.GetAll()));
        }

        public IActionResult StatusChange(int id)
        {
            var mail = _mailService.GetById(id);

            mail.Read = mail.Read == true ? false : true;

            _mailService.Update(mail);

            return RedirectToAction("Index");
        }
    }
}
