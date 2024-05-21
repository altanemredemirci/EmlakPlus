using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.SliderDTO;
using EmlakPlus.BLL;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using EmlakPlus.BLL.DTOs.WhoWeAreDTO;

namespace EmlakPlus.WEBUI.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IWhoWeAreService _whoWeAreService;
        private readonly IMapper _mapper;

        public WhoWeAreController(IWhoWeAreService whoWeAreService, IMapper mapper)
        {
            _whoWeAreService = whoWeAreService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var whoWeAre = _whoWeAreService.GetOne();
            return View(_mapper.Map<ResultWhoWeAreDTO>(whoWeAre));
        }

        public IActionResult Edit(int id)
        {
            var whoWeAre = _whoWeAreService.GetOne();
            return View(_mapper.Map<UpdateWhoWeAreDTO>(whoWeAre));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateWhoWeAreDTO dto, IFormFile file)
        {
            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {
                var whoWeAre = _whoWeAreService.GetOne();

                if (whoWeAre == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Code = 404,
                        Title = "Slider Bulunamadı",
                        Description = "Lütfen seçtiğiniz yapıyı tekrar kontrol ediniz.",
                        ReturnUrl = "/whoWeAre/Index",
                        Css = "text-danger"
                    };
                    return View("Error", error);
                }

                if (file != null)
                {
                    if (whoWeAre.Image != null)
                    {
                        ImageMethods.DeleteImage(whoWeAre.Image);
                    }

                    dto.Image = await ImageMethods.UploadImage(file);
                }

                _whoWeAreService.Update(_mapper.Map<WhoWeAre>(dto));
                return RedirectToAction("Index");
            }

            return View(dto);
        }

    }
}
