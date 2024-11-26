using LoadDW.Data.Entities;
using LoadDW.Data.Entities.Northwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDW.Data.Context
{
    public partial class NorthwindContext: DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options): base(options)
        {
            
        }

        #region Sets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers{ get; set; }
        public DbSet<Supplier> Suppliers{ get; set; }
        #endregion

    }
}
