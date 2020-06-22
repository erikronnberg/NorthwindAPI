using NorthwindAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Data
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly NorthwindContext _northwindContext;

        public NorthwindRepository (NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public void AddSupplier(Supplier suppliers)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(Supplier suppliers)
        {
            throw new NotImplementedException();
        }

        public async Task<Supplier[]> GetAllSuppliersAsync()
        {
            IQueryable<Supplier> query = _northwindContext.Suppliers.Include(c => c.Products).OrderByDescending(c => c.CompanyName);

            return await query.ToArrayAsync();
        }

        public async Task<Supplier[]> GetAllSuppliersByCountry(string Country)
        {
            IQueryable<Supplier> query = _northwindContext.Suppliers.Include(c => c.Products).Where(c => c.Country == Country).OrderByDescending(c => c.CompanyName);

            return await query.ToArrayAsync();
        }

        public Task<Supplier> GetSupplierAsync(string CompanyName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
