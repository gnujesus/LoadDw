using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimSuppliers")]


    public class DimSupplier
    {
        [Key]
        public int SuppliersKey { get; set; }

        [Required]
        public int SuppliersID { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }
    }
}

