using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimCategories")]

    public class DimCategory
    {
        [Key]
        public int CategoriesKey { get; set; }

        [Required]
        public int CategoriesID { get; set; }

        [StringLength(40)]
        public string CategoryName { get; set; }
    }
}

