using System;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetSuppliersWithProductsAsync();
            var supplierViewModels = _mapper.Map<SupplierViewModel[]>(suppliers);
            return View(supplierViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<SupplierViewModel, SupplierViewModel>(supplierViewModel);
                await _supplierService.AddSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplierViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
            return View(supplierViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
            return View(supplierViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var supplier = _mapper.Map<SupplierViewModel, SupplierViewModel>(supplierViewModel);
                    await _supplierService.UpdateSupplierAsync(supplier);
                }
                catch (Exception)
                {
                    if (!await SupplierExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplierViewModel);
        }

        //implementando a busca de produtos pelo vinculo relacional
        public async Task<IActionResult> products()
        {
            var suppliers = await _supplierService.GetSuppliersWithProductsAsync();
            return View(suppliers);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _supplierService.GetSupplierByIdAsync(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
            return View(supplierViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supplierService.RemoveSupplierAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SupplierExists(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            return supplier != null;
        }
    }
}
