﻿using AutoMapper;
using EmlakPlus.BLL;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using EmlakPlus.BLL.DTOs.ProductDTO;
using EmlakPlus.Entity;
using EmlakPlus.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using System.Text;
using System.Text.Json;

namespace EmlakPlus.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly ICityService _cityService;
        private readonly IProductTypeService _productTypeService;
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;


        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IProductService productService, IProductDetailService productDetailService, ICityService cityService, IProductTypeService productTypeService, IAgencyService agencyService, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _cityService = cityService;
            _productTypeService = productTypeService;
            _agencyService = agencyService;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;

        }

        //public IActionResult Index()
        //{
        //    return View(_mapper.Map<List<ResultProductDTO>>(_productService.GetAll()));
        //}

        //public IActionResult Create()
        //{
        //    ViewBag.Cities = _cityService.GetAll();
        //    ViewBag.ProductTypes = _productTypeService.GetAll();
        //    ViewBag.Agencies = _agencyService.GetAll();
        //    return View(new CreateProductDetailDTO());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateProductDetailDTO dto, IFormFile file, IFormFile[] files)
        //{
        //    ModelState.Remove("CoverImage");
        //    if (ModelState.IsValid)
        //    {
        //        if (file == null)
        //        {
        //            ViewBag.Cities = _cityService.GetAll();
        //            ViewBag.ProductTypes = _productTypeService.GetAll();
        //            ViewBag.Agencies = _agencyService.GetAll();
        //            ModelState.AddModelError("", "Ikon için dosya yüklenmedi.");
        //            return View(dto);
        //        }

        //        if (files.Length == 0)
        //        {
        //            ViewBag.Cities = _cityService.GetAll();
        //            ViewBag.ProductTypes = _productTypeService.GetAll();
        //            ViewBag.Agencies = _agencyService.GetAll();
        //            ModelState.AddModelError("", "İlan Detay Resimleri yüklenmedi.");
        //            return View(dto);
        //        }

        //        dto.Product.CoverImage = await ImageMethods.UploadImage(file);

        //        foreach (var item in files)
        //        {
        //            Entity.Image image = new Entity.Image();
        //            image.Url = await ImageMethods.UploadImage(item);
        //            dto.Images.Add(image);
        //        }
        //        dto.Product.Status = true;
        //        dto.PublishDate = DateTime.Now;
        //        //_productService.Create(_mapper.Map<Product>(dto.Product));
        //        _productDetailService.Create(_mapper.Map<ProductDetail>(dto));

        //        return RedirectToAction("Index");

        //    }

        //    ViewBag.Cities = _cityService.GetAll();
        //    ViewBag.ProductTypes = _productTypeService.GetAll();
        //    ViewBag.Agencies = _agencyService.GetAll();
        //    return View(dto);
        //}


        //public IActionResult Edit(int id)
        //{
        //    if (id < 1)
        //    {
        //        ErrorViewModel error = new ErrorViewModel()
        //        {
        //            Code = 102,
        //            Title = "İlan Bulunamadı",
        //            Description = "Lütfen varolan bir ilanı seçiniz.",
        //            ReturnUrl = "/Product/Index",
        //            Css = "text-danger"
        //        };
        //        return View("Error", error);
        //    }

        //    var productdetail = _productDetailService.GetById(id);

        //    if (productdetail == null)
        //    {
        //        ErrorViewModel error = new ErrorViewModel()
        //        {
        //            Code = 102,
        //            Title = "İlan Bulunamadı",
        //            Description = "Lütfen varolan bir ilanı seçiniz.",
        //            ReturnUrl = "/Product/Index",
        //            Css = "text-danger"
        //        };
        //        return View("Error", error);
        //    }

        //    var model = _mapper.Map<UpdateProductDetailDTO>(productdetail);

        //    ViewBag.Cities = _cityService.GetAll();
        //    ViewBag.ProductTypes = _productTypeService.GetAll();
        //    ViewBag.Agencies = _agencyService.GetAll();
        //    return View(model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(UpdateProductDetailDTO dto, IFormFile file, IFormFile[] files)
        //{
        //    ModelState.Remove("Images");
        //    if (ModelState.IsValid)
        //    {
        //        var productDetail = _productDetailService.GetById(dto.ProductId);

        //        if (productDetail == null)
        //        {
        //            ErrorViewModel error = new ErrorViewModel()
        //            {
        //                Code = 102,
        //                Title = "İlan Bulunamadı",
        //                Description = "Lütfen varolan bir ilanı seçiniz.",
        //                ReturnUrl = "/Product/Index",
        //                Css = "text-danger"
        //            };
        //            return View("Error", error);
        //        }

        //        if (file != null)
        //        {
        //            ImageMethods.DeleteImage(productDetail.Product.CoverImage);
        //            dto.Product.CoverImage = await ImageMethods.UploadImage(file);
        //        }
        //        else
        //        {
        //            dto.Product.CoverImage = productDetail.Product.CoverImage;
        //        }

        //        if (files.Length != 0)
        //        {
        //            productDetail.Images.ForEach(i => ImageMethods.DeleteImage(i.Url));

        //            foreach (var item in files)
        //            {
        //                Entity.Image image = new Entity.Image();
        //                image.Url = await ImageMethods.UploadImage(item);
        //                dto.Images.Add(image);
        //            }
        //        }

        //        else
        //        {
        //            foreach (var item in productDetail.Images)
        //            {
        //                Entity.Image image = new Entity.Image();
        //                image.Url = item.Url;
        //                image.ProductDetailId = item.ProductDetailId;
        //                dto.Images.Add(image);
        //            }
        //        }

        //        dto.PublishDate = DateTime.Now;

        //        _productDetailService.Update(_mapper.Map<ProductDetail>(dto));
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Cities = _cityService.GetAll();
        //    ViewBag.ProductTypes = _productTypeService.GetAll();
        //    ViewBag.Agencies = _agencyService.GetAll();
        //    return View(dto);
        //}


        public IActionResult Delete(int id)
        {
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

            _productService.Delete(product);
            ImageMethods.DeleteImage(product.CoverImage);
            return RedirectToAction("Index");
        }


        public IActionResult StatusChange(int id)
        {
            var product = _productService.GetById(id);

            product.Status = product.Status == true ? false : true;

            _productService.Update(product);

            return RedirectToAction("Index");
        }



        //RESTFUL-API

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient(); //Web Api istemcisi
            var response = await httpClient.GetAsync("https://localhost:7176/api/Product"); //Api result url

            if (response.IsSuccessStatusCode) //apiden cevap döndü mü?
            {
                var content = await response.Content.ReadAsStreamAsync(); //Get edilen veriyi Stream ile dataset oluştur.

                var products = await JsonSerializer.DeserializeAsync<List<Product>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive=true,
                    MaxDepth=64
                });

                return View(_mapper.Map<List<ResultProductDTO>>(products));
            }


            return BadRequest();
           
        }

        public IActionResult Create()
        {
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(new CreateProductDetailDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDetailDTO dto, IFormFile file, IFormFile[] files)
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

                if (files.Length == 0)
                {
                    ViewBag.Cities = _cityService.GetAll();
                    ViewBag.ProductTypes = _productTypeService.GetAll();
                    ViewBag.Agencies = _agencyService.GetAll();
                    ModelState.AddModelError("", "İlan Detay Resimleri yüklenmedi.");
                    return View(dto);
                }

                dto.Product.CoverImage = await ImageMethods.UploadImage(file);

                foreach (var item in files)
                {
                    Entity.Image image = new Entity.Image();
                    image.Url = await ImageMethods.UploadImage(item);
                    dto.Images.Add(image);
                }
                dto.Product.Status = true;
                dto.PublishDate = DateTime.Now;


                var productDetail = _mapper.Map<ProductDetail>(dto);
                var httpClient = _httpClientFactory.CreateClient();

                var jsonData = JsonSerializer.Serialize(productDetail);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7176/api/Product/", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                } 
            }

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
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


            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7176/api/Product/" + id);
            if (!response.IsSuccessStatusCode)
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

            var content = await response.Content.ReadAsStreamAsync();

            var productDetail = await JsonSerializer.DeserializeAsync<ProductDetail>(content);

            var model = _mapper.Map<UpdateProductDetailDTO>(productDetail);

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductDetailDTO dto, IFormFile file, IFormFile[] files)
        {
            ModelState.Remove("Images");
            if (ModelState.IsValid)
            {
                var productDetail = _productDetailService.GetById(dto.ProductId);

                if (productDetail == null)
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
                    ImageMethods.DeleteImage(productDetail.Product.CoverImage);
                    dto.Product.CoverImage = await ImageMethods.UploadImage(file);
                }
                else
                {
                    dto.Product.CoverImage = productDetail.Product.CoverImage;
                }

                if (files.Length != 0)
                {
                    productDetail.Images.ForEach(i => ImageMethods.DeleteImage(i.Url));

                    foreach (var item in files)
                    {
                        Entity.Image image = new Entity.Image();
                        image.Url = await ImageMethods.UploadImage(item);
                        dto.Images.Add(image);
                    }
                }

                else
                {
                    foreach (var item in productDetail.Images)
                    {
                        Entity.Image image = new Entity.Image();
                        image.Url = item.Url;
                        image.ProductDetailId = item.ProductDetailId;
                        dto.Images.Add(image);
                    }
                }

                dto.PublishDate = DateTime.Now;

                _productDetailService.Update(_mapper.Map<ProductDetail>(dto));
                return RedirectToAction("Index");
            }

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.ProductTypes = _productTypeService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(dto);
        }




    }
}
