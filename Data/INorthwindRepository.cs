using NorthwindAPI.Data.Entities;
using System.Threading.Tasks;

namespace NorthwindAPI.Data
{
    public interface INorthwindRepository
    {
        Task<bool> SaveChangesAsync();
        void AddSupplier(Supplier suppliers);
        void DeleteSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        Task<Supplier[]> GetAllSuppliersAsync();
        Task<Supplier> GetSuppliersAsync(int id);
    }
}