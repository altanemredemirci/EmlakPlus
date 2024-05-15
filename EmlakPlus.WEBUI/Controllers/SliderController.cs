﻿using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.SliderDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService,IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var slider = _sliderService.GetAll();
            return View(_mapper.Map<List<ResultSliderDTO>>(slider));
        }

        public IActionResult Edit(int id)
        {
            var slider = _sliderService.GetOne(i=> i.Id==id);
            return View(_mapper.Map<UpdateSliderDTO>(slider));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateSliderDTO dto, IFormFile file1, IFormFile file2)
        {
            ModelState.Remove("ImageUrl1");
            ModelState.Remove("ImageUrl2");
            if (ModelState.IsValid)
            {
                var slider = _sliderService.GetOne(i => i.Id == dto.Id);

                if (slider == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 404,
                        Title = "Slider Bulunamadı",
                        Description = "Lütfen seçtiğiniz yapıyı tekrar kontrol ediniz.",
                        ReturnUrl = "/Slider/Index",
                        Css = "text-danger"
                    };
                    return View("Error", error);
                }

                if (file1 != null)
                {
                    if (slider.ImageUrl1 != null)
                    {
                        ImageMethods.DeleteImage(slider.ImageUrl1);
                    }
                    
                    dto.ImageUrl1 = await ImageMethods.UploadImage(file1);
                }

                if (file2 != null)
                {
                    if (slider.ImageUrl2 != null)
                    {
                        ImageMethods.DeleteImage(slider.ImageUrl2);
                    }
                  
                    dto.ImageUrl2 = await ImageMethods.UploadImage(file2);
                }

                _sliderService.Update(_mapper.Map<Slider>(dto));
                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}
