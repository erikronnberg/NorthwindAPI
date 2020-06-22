using NorthwindAPI.Data.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Data
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly NorthwindContext _northwindContext;

        public NorthwindRepository(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public void AddSupplier(Supplier supplier)
        {
            _northwindContext.Suppliers.Add(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _northwindContext.Suppliers.AddOrUpdate(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            var products = _northwindContext.Products.Where(c => c.Supplier.SupplierID == supplier.SupplierID).ToArray();
            foreach (var s in products)
            {
                s.Supplier = null;
            }
            _northwindContext.Suppliers.Remove(supplier);
        }


        public async Task<Supplier[]> GetAllSuppliersAsync()
        {
            IQueryable<Supplier> query = _northwindContext.Suppliers.Include(c => c.Products).OrderByDescending(c => c.CompanyName);

            return await query.ToArrayAsync();
        }

        public async Task<Supplier> GetSuppliersAsync(int id)
        {
            var query = _northwindContext.Suppliers.Where(c => c.SupplierID == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _northwindContext.SaveChangesAsync();
            return true;
        }
    }
}