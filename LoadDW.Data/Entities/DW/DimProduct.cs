using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimProducts")]

    public class DimProduct
    {
        [Key] 
        public int ProductKey { get; set; } // Maps to ProductKey in the database

        [Required] 
        public int ProductID { get; set; } // Maps to ProductID (PK, int)

        public int? CategoriesID { get; set; } // Maps to CategoriesID (nullable FK)

        public int? SuppliersID { get; set; } // Maps to SuppliersID (nullable FK)

        [StringLength(100)] // Matches the nvarchar(100) column size
        public string ProductName { get; set; } // Maps to ProductName (nullable)
    }
}

