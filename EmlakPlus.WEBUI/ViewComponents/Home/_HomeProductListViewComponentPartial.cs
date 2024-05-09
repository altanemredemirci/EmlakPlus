﻿using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _HomeProductListViewComponentPartial(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll(i=>i.Status==true);

            var resultProducts = _mapper.Map<List<ResultProductDTO>>(products);
            return View(resultProducts);
        }
    }
}
