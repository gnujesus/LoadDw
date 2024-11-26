using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimShippers")]

    public class DimShipper
    {
        [Key] 
        public int ShipperKey { get; set; } // Maps to ShipperKey in the database

        [Required] 
        public int ShipperID { get; set; } // Maps to ShipperID (PK, int)

        [StringLength(50)] // Matches the nvarchar(50) column size
        public string CompanyName { get; set; } // Maps to CompanyName (nullable)
    }
}

