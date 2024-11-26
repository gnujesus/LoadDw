using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDW.Data.Entities.Northwind
{

    [Table("Employees")]

    public class Employee
    {
        [Key] // Primary key
        public int EmployeeID { get; set; } // Maps to EmployeeID in the database

        [Required]
        [StringLength(20)]
        public string LastName { get; set; } // Maps to LastName

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; } // Maps to FirstName

        [StringLength(30)]
        public string Title { get; set; } // Maps to Title

        [StringLength(25)]
        public string TitleOfCourtesy { get; set; } // Maps to TitleOfCourtesy

        public DateTime? BirthDate { get; set; } // Maps to BirthDate

        public DateTime? HireDate { get; set; } // Maps to HireDate

        [StringLength(60)]
        public string Address { get; set; } // Maps to Address

        [StringLength(15)]
        public string City { get; set; } // Maps to City

        [StringLength(15)]
        public string Region { get; set; } // Maps to Region

        [StringLength(10)]
        public string PostalCode { get; set; } // Maps to PostalCode

        [StringLength(15)]
        public string Country { get; set; } // Maps to Country

        [StringLength(24)]
        public string HomePhone { get; set; } // Maps to HomePhone

        [StringLength(4)]
        public string Extension { get; set; } // Maps to Extension

        public byte[] Photo { get; set; } // Maps to Photo (image)

        public string Notes { get; set; } // Maps to Notes (ntext)

        public int? ReportsTo { get; set; } // Maps to ReportsTo (FK)

        [StringLength(255)]
        public string PhotoPath { get; set; } // Maps to PhotoPath
    }
}
