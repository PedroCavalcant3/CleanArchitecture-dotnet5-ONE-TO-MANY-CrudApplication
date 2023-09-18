using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ISupplierService supplierService, IMapper mapper)
        {
            _productService = productService;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            ViewBag.Suppliers = suppliers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(productViewModel);
                return RedirectToAction(nameof(Index));
            }

            var suppliers = await _supplierService.GetSuppliersAsync();
            ViewBag.Suppliers = suppliers;

            return View(productViewModel);
        }

        
    }
}
