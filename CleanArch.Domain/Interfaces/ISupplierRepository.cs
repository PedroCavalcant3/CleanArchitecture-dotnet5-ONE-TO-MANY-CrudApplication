using CleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<IEnumerable<Supplier>> GetSuppliersWithProductsAsync(); // Adicional
        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task RemoveSupplierAsync(int id);
        Task SaveChangesAsync();
        void Dispose();
    }
}
