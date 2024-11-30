using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace LoadDW.Data.Entities.Northwind
{

[Table("FactOrders", Schema ="dbo")]
public partial class FactOrder
{

    [Key]
    public int OrderNumber { get; set; }

    public string CustomerId { get; set; }

    public int ShipperId { get; set; }

    public int EmployeeId { get; set; }

    public int? DateKey { get; set; }

    public int? ProductKey { get; set; }

    public int? EmployeeKey { get; set; }

    public int? Shipper { get; set; }

    public int? CustomerKey { get; set; }

    public string Country { get; set; }

    public double TotalSales { get; set; }

    public int? Quantity { get; set; }

}

}
