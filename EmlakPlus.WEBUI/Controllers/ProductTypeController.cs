using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmlakPlus.DAL.Concrete.EfCore;
using EmlakPlus.Entity;
using EmlakPlus.BLL.Abstract;
using AutoMapper;
using EmlakPlus.BLL.DTOs.ProductTypeDTO;

namespace EmlakPlus.WEBUI.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var productTypes = _productTypeService.GetAll();
            var models = _mapper.Map<List<ResultProductTypeDTO>>(productTypes);
            return View(models);
        } 
        //[HttpGet] Default get olarak tanımlıdır.
        public IActionResult Create()
        {
            return View(new CreateProductTypeDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductTypeDTO dto, IFormFile file)        
        {
            ModelState.Remove("Icon");
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("", "Ikon için dosya yüklenmedi.");
                    return View(dto);
                }

                if (file.ContentType == "image/png" || file.ContentType == "image/jpg" || file.ContentType == "image/jpeg")
                {
                    string newFileName = GenerateUniqueFileName();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    dto.Icon = newFileName;

                    _productTypeService.Create(_mapper.Map<ProductType>(dto));
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Ikon dosya tipi png,jpg veya jpeg olmalıdır.");
                return View(dto);

            }
           
            return View(dto);
        }

        private static string GenerateUniqueFileName(string fileExtension =".png")
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var uniqueName = $"{timestamp}{fileExtension}";

            return uniqueName;
        }
    }
}
