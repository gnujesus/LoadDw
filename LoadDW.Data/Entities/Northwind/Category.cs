using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.Northwind
{

    [Table("Categories")]

    public class Category
    {
        [Key] // Primary key
        public int CategoryID { get; set; } // Maps to CategoryID in the database

        [Required]
        [StringLength(15)] // Matches the nvarchar(15) column size
        public string CategoryName { get; set; } // Maps to CategoryName

        public string Description { get; set; } // Maps to Description (ntext)

        public byte[] Picture { get; set; } // Maps to Picture (image)
    }
}
