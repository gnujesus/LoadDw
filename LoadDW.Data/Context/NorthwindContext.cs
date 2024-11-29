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
        public DbSet<VWSale> VWSales { get; set; }
        public DbSet<VWCustomersServedByEmployee> VWCustomersServedByEmployees { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VWSale>(entity => {
                    entity.HasNoKey()
                          .ToView("VWSales", "dbo");

                    entity.Property(e => e.CompanyName)
                          .IsRequired()
                          .HasMaxLength(40);

                    entity.Property(e => e.CustomerId)
                          .IsRequired()
                          .HasMaxLength(5)
                          .IsFixedLength()
                          .HasColumnName("CustomerID");

                    entity.Property(e => e.CustomerName)
                          .IsRequired()
                          .HasMaxLength(49);

                    entity.Property(e => e.EmployeeId)
                          .HasColumnName("EmployeeID");

                    entity.Property(e => e.EmployeeName)
                          .IsRequired()
                          .HasMaxLength(31);

                    entity.Property(e => e.ShipperId)
                          .HasColumnName("ShipperID");
            });

            modelBuilder.Entity<VWCustomersServedByEmployee>(entity => {
                    entity.HasNoKey()
                          .ToView("CustomersServedByEmployee", "dbo");

                    entity.Property(e => e.FirstName)
                          .IsRequired()
                          .HasMaxLength(40);

                    entity.Property(e => e.LastName)
                          .IsRequired()
                          .HasMaxLength(40);

                    entity.Property(e => e.TotalCustomers)
                          .IsRequired()
                          .HasColumnName("Total_Customers");

            });
        }
    }
}
