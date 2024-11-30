using LoadDW.Data.Entities.DW;
using LoadDW.Data.Entities.Northwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDW.Data.Context
{
    public partial class DwContext: DbContext
    {
        public DwContext(DbContextOptions<DwContext> options): base(options)
        {
            
        }

        #region Sets
        public DbSet<DimCustomer> DimCustomers { get; set; }
        public DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimProduct> DimProducts { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }
        public DbSet<DimSupplier> DimSuppliers { get; set; }
        public DbSet<DimCategory> DimCategories { get; set; }
        public DbSet<FactOrder> FactOrders { get; set; }
        public DbSet<FactCustomersServedByEmployee> FactCustomersServedByEmployees { get; set; }
        #endregion

    }
}
