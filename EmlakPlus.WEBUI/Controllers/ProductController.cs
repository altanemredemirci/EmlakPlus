using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EmlakPlus.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICityService _cityService;
        private readonly IProductTypeService _productTypeService;
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICityService cityService, IProductTypeService productTypeService, IAgencyService agencyService, IMapper mapper)
        {
            _productService = productService;
            _cityService = cityService;
            _productTypeService = productTypeService;
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<ResultProductDTO>>(_productService.GetAll()));
        }

        public IActionResult Create()
        {
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(new CreateProductDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDTO dto, IFormFile file)
        {
            ModelState.Remove("CoverImage");
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ViewBag.Cities = _cityService.GetAll();
                    ViewBag.ProductTypes = _productTypeService.GetAll();
                    ViewBag.Agencies = _agencyService.GetAll();
                    ModelState.AddModelError("", "Ikon için dosya yüklenmedi.");
                    return View(dto);
                }

                dto.CoverImage = await ImageMethods.UploadImage(file);

                _productService.Create(_mapper.Map<Product>(dto));

                return RedirectToAction("Index");

            }

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(dto);
        }


        public IActionResult Edit(int id)
        {
            if (id < 1)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Code = 102,
                    Title = "İlan Bulunamadı",
                    Description = "Lütfen varolan bir ilanı seçiniz.",
                    ReturnUrl = "/Product/Index",
                    Css = "text-danger"
                };
                return View("Error", error);
            }

            var product = _productService.GetById(id);

            if (product == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Code = 102,
                    Title = "İlan Bulunamadı",
                    Description = "Lütfen varolan bir ilanı seçiniz.",
                    ReturnUrl = "/Product/Index",
                    Css = "text-danger"
                };
                return View("Error", error);
            }

            var model = _mapper.Map<UpdateProductDTO>(product);

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductDTO dto, IFormFile file) 
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(dto.Id);

                if (product == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 102,
                        Title = "İlan Bulunamadı",
                        Description = "Lütfen varolan bir ilanı seçiniz.",
                        ReturnUrl = "/Product/Index",
                        Css = "text-danger"
                    };
                    return View("Error", error);
                }

                if (file != null)
                {
                    ImageMethods.DeleteImage(product.CoverImage);
                    dto.CoverImage=await ImageMethods.UploadImage(file);
                }

                _productService.Update(_mapper.Map<Product>(dto));
                return RedirectToAction("Index");
            }

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(dto);
        }





        public IActionResult StatusChange(int id)
        {
            var product = _productService.GetById(id);

            product.Status = product.Status == true ? false : true;

            _productService.Update(product);

            return RedirectToAction("Index");
        }
    }
}
