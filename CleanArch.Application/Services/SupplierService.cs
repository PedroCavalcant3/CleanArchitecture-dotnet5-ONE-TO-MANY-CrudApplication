using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);
        }

        public async Task<SupplierViewModel> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            return _mapper.Map<SupplierViewModel>(supplier);
        }

        public async Task<IEnumerable<SupplierViewModel>> GetSuppliersWithProductsAsync()
        {
            var suppliers = await _supplierRepository.GetSuppliersWithProductsAsync();
            return _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers);
        }

        public async Task AddSupplierAsync(SupplierViewModel supplierViewModel)
        {
            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.AddSupplierAsync(supplier);
        }

        public async Task UpdateSupplierAsync(SupplierViewModel supplierViewModel)
        {
            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.UpdateSupplierAsync(supplier);
        }

        public async Task RemoveSupplierAsync(int id)
        {
            await _supplierRepository.RemoveSupplierAsync(id);
        }

        public void Dispose()
        {
            _supplierRepository.Dispose();
        }
    }
}
