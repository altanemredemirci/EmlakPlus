using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.MailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardLast4MailViewComponentPartial:ViewComponent
    {
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public _DashboardLast4MailViewComponentPartial(IMailService mailService, IMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {

            var mails = _mailService.GetLast4();

            return View(_mapper.Map<List<ResultMailDTO>>(mails));
        }
    }
}
