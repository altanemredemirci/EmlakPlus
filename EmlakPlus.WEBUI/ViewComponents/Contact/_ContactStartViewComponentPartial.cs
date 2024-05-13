using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ContactDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Contact
{
    public class _ContactStartViewComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public _ContactStartViewComponentPartial(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ResultContactDTO>(_contactService.GetOne()));
        }
    }
}
