using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDW.Data.Context;
using LoadDW.Data.Entities.DW;
using LoadDW.Data.Entities.Northwind;
using LoadDW.Data.Interfaces;
using LoadDW.Data.Result;
using Microsoft.EntityFrameworkCore;

namespace LoadDW.Data.Services
{
    public class DataServiceDw : IDataServiceDw
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DwContext _dwContext;

        public DataServiceDw(NorthwindContext northwindContext, DwContext dwContext)
        {
            this._northwindContext = northwindContext;
            this._dwContext = dwContext;
        }

        public async Task<OperationResult> LoadDimCustomer()
        {
            OperationResult result = new OperationResult();

            try
            {
                var customers = _northwindContext.Customers.Select(cust => new DimCustomer()
                {
                    CustomerID = cust.CustomerID,
                    CompanyName = cust.CompanyName
                }).AsNoTracking().ToList();

                await _dwContext.DimCustomers.AddRangeAsync(customers);
                await _dwContext.DimCustomers.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<OperationResult> LoadDimEmployee()
        {
            OperationResult result = new OperationResult();

            try
            {
                var employees = _northwindContext.Employees.Select(emp => new DimEmployee()
                {
                    EmployeeID = emp.EmployeeID,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName
                }).AsNoTracking().ToList();

                await _dwContext.DimEmployees.AddRangeAsync(employees);
                await _dwContext.DimEmployees.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<OperationResult> LoadDimProduct()
        {
            OperationResult result = new OperationResult();

            try
            {
                var products = _northwindContext.Products.Select(prod => new DimProduct()
                {
                    ProductID = prod.ProductID,
                    ProductName = prod.ProductName,
                    CategoriesID = prod.CategoryID,
                    SuppliersID = prod.SupplierID
                }).AsNoTracking().ToList();

                await _dwContext.DimProducts.AddRangeAsync(products);
                await _dwContext.DimProducts.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<OperationResult> LoadDimShipper()
        {
            OperationResult result = new OperationResult();

            try
            {
                var shippers = _northwindContext.Shippers.Select(ship => new DimShipper()
                {
                    ShipperID = ship.ShipperID,
                    CompanyName = ship.CompanyName
                }).AsNoTracking().ToList();

                await _dwContext.DimShippers.AddRangeAsync(shippers);
                await _dwContext.DimShippers.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<OperationResult> LoadDimSupplier()
        {
            OperationResult result = new OperationResult();

            try
            {
                var suppliers = _northwindContext.Suppliers.Select(supp => new DimSupplier()
                {
                    SuppliersID = supp.SupplierID,
                    CompanyName = supp.CompanyName
                }).AsNoTracking().ToList();

                await _dwContext.DimSuppliers.AddRangeAsync(suppliers);
                await _dwContext.DimSuppliers.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public async Task<OperationResult> LoadDimCategory()
        {
            OperationResult result = new OperationResult();

            try
            {
                // Get categories from Northwind and map to DimCategory
                var query = from c in _northwindContext.Categories
                            select new DimCategory
                            {
                                CategoriesID = c.CategoryID,
                                CategoryName = c.CategoryName,
                            };

                var categories = query.AsNoTracking().ToList();

                await _dwContext.DimCategories.AddRangeAsync(categories);
                await _dwContext.DimCategories.ExecuteDeleteAsync();
                await _dwContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading DimCategory: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult> LoadFactSales() {
            OperationResult result = new OperationResult();

            try {
                var sales = await _northwindContext.VWSales.AsNoTracking().ToListAsync();

                await _dwContext.FactOrders.ExecuteDeleteAsync();

                foreach (var cd in sales)
                {
                    var customer = await _dwContext.DimCustomers
                        .SingleOrDefaultAsync(c=> c.CustomerID == cd.CustomerId);

                    var employee = await _dwContext.DimEmployees
                        .SingleOrDefaultAsync(e => e.EmployeeID== cd.EmployeeId);

                    var shipper = await _dwContext.DimShippers
                        .SingleOrDefaultAsync(s => s.ShipperID == cd.ShipperId);

                    var product = await _dwContext.DimProducts
                        .SingleOrDefaultAsync(p => p.ProductID == cd.ProductId);

                    FactOrder factOrder = new FactOrder()
                    {

                        TotalSales = cd.TotalVentas,
                        Country = cd.Country,
                        CustomerKey = customer.CustomerKey,
                        CustomerId = customer.CustomerID,
                        EmployeeKey = employee.EmployeeKey,
                        EmployeeId = employee.EmployeeID,
                        DateKey = cd.DateKey,
                        Shipper = shipper.ShipperKey,
                        Quantity = cd.Cantidad,
                        ProductKey = product.ProductID,
                    };

                    await _dwContext.FactOrders.AddAsync(factOrder);

                    await _dwContext.SaveChangesAsync();
                }


            } 
            catch (Exception ex) {
                result.Success = false;
                result.Message = $"Error loading FactSales: {ex.Message}";
            }

            return result;
        }
        
        public async Task<OperationResult> LoadFactServedClients() {
            OperationResult result = new OperationResult();

            try {
                var customersServedByEmployees = await _northwindContext.VWCustomersServedByEmployees.AsNoTracking().ToListAsync();

                await _dwContext.FactCustomersServedByEmployees.ExecuteDeleteAsync();

                foreach (var cd in customersServedByEmployees)
                {
                    //copilot, use the class FactCustomerServedByEmployee and replicate the behavior of the 
                    // method LoadFactSales, but here

                    var employee = await _dwContext.DimEmployees
                        .SingleOrDefaultAsync(e => e.EmployeeID == cd.EmployeeKey);

                    FactCustomersServedByEmployee factCustomersServedByEmployee =
                        new FactCustomersServedByEmployee()
                        {
                            EmployeeKey = cd.EmployeeKey,
                            FirstName = cd.FirstName,
                            LastName = cd.LastName,
                            TotalClients = cd.TotalCustomers
                        };
                    
                    await _dwContext.FactCustomersServedByEmployees.AddAsync(factCustomersServedByEmployee);

                    await _dwContext.SaveChangesAsync();
                }

            } 
            catch (Exception ex) {
                result.Success = false;
                result.Message = $"Error loading FactSales: {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult> LoadDHW()
        {

            OperationResult result = new OperationResult();
            try
            {
                /*
                await this.LoadDimCategory();
                await this.LoadDimCustomer();
                await this.LoadDimSupplier();
                await this.LoadDimProduct();
                await this.LoadDimShipper();
                await this.LoadDimEmployee();
                */

                // await this.LoadFactSales();
                await this.LoadFactServedClients();

                result.Success = true;
                result.Message = "Success";
                return result;
            }
            catch (Exception e) {
                result.Success = false;
                result.Message = e.Message;
                return result;
            }
        }

    }
}
