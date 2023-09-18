using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ISupplierService supplierService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            ViewBag.Suppliers = suppliers;
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                 _productService.Add(productViewModel);
                return RedirectToAction(nameof(Index));
            }

            var suppliers = await _supplierService.GetSuppliersAsync();
            ViewBag.Suppliers = suppliers;

            return View(productViewModel);
        }
    }
}
