using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDW.Data.Entities.Northwind
{
    public class VWSale
    {
    public string CustomerId { get; set; }

    public string CustomerName { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public int ShipperId { get; set; }

    public string CompanyName { get; set; }

    public int? DateKey { get; set; }

    public int? Afio { get; set; }

    public int? Mes { get; set; }

    public double? TotalVentas { get; set; }

    public int? Cantidad { get; set; }
    }
}
