using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimEmployees")]

    public class DimEmployee 
    {
        [Key] 
        public int EmployeeKey { get; set; } // Maps to EmployeeKey in the database

        [StringLength(50)] // Matches the nvarchar(50) column size
        public string FirstName { get; set; } // Maps to FirstName (nullable)

        [StringLength(50)] // Matches the nvarchar(50) column size
        public string LastName { get; set; } // Maps to LastName (nullable)

        [Required] 
        public int EmployeeID { get; set; } 
    }
}

