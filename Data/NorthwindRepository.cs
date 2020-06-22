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
            IQueryable<Supplier> query = _northwindContext.Suppliers;

            // Order It
            query = query.OrderByDescending(c => c.CompanyName);

            return await query.ToArrayAsync();
        }

        public Task<Supplier[]> GetAllSuppliersByCountry(string Country)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSuppliersAsync(string moniker)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
