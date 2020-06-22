using NorthwindAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Data
{
    public interface INorthwindRepository
    {
        Task<bool> SaveChangesAsync();
        void AddSupplier(Supplier suppliers);
        void DeleteSupplier(Supplier suppliers);
        Task<Supplier[]> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierAsync(string name);
        Task<Supplier[]> GetAllSuppliersByCountry(string Country);
    }
}
