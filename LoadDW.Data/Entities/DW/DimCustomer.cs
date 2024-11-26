using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDW.Data.Entities.DW
{

    [Table("DimCustomers")]

    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }

        [Required]
        public string CustomerID { get; set; }

        [StringLength(40)]
        public string CompanyName { get; set; }
    }
}

