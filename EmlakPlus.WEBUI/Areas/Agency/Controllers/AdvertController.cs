using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Areas.Agency.Controllers
{
    [Area("Agency")]
    public class AdvertController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public AdvertController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var models = _mapper.Map<List<ResultProductDTO>>(_productService.GetAll(i => i.AgencyId == 1 && i.Status==true ));
            return View(models);
        }

        public IActionResult ExpiredProduct()
        {
            var models = _mapper.Map<List<ResultProductDTO>>(_productService.GetAll(i => i.AgencyId == 1 && i.Status == false));
            return View(models);
        }
    }
}
