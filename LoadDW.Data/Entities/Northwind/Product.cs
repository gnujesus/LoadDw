using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.Northwind
{

    [Table("Products")]

    public class Product
    {
        [Key] // Primary key
        public int ProductID { get; set; } // Maps to ProductID in the database

        [Required]
        [StringLength(40)] // Matches the nvarchar(40) column size
        public string ProductName { get; set; } // Maps to ProductName

        public int? SupplierID { get; set; } // Maps to SupplierID (nullable FK)

        public int? CategoryID { get; set; } // Maps to CategoryID (nullable FK)

        [StringLength(20)] // Matches the nvarchar(20) column size
        public string QuantityPerUnit { get; set; } // Maps to QuantityPerUnit

        public decimal? UnitPrice { get; set; } // Maps to UnitPrice (money)

        public short? UnitsInStock { get; set; } // Maps to UnitsInStock (smallint)

        public short? UnitsOnOrder { get; set; } // Maps to UnitsOnOrder (smallint)

        public short? ReorderLevel { get; set; } // Maps to ReorderLevel (smallint)

        [Required]
        public bool Discontinued { get; set; } // Maps to Discontinued (bit, NOT NULL)
    }
}
