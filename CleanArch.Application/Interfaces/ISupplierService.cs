using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task<IEnumerable<SupplierViewModel>> GetSuppliersAsync();
        Task<SupplierViewModel> GetSupplierByIdAsync(int id);
        Task<IEnumerable<SupplierViewModel>> GetSuppliersWithProductsAsync();
        Task AddSupplierAsync(SupplierViewModel supplierViewModel);
        Task UpdateSupplierAsync(SupplierViewModel supplierViewModel);
        Task RemoveSupplierAsync(int id);
    }
}
