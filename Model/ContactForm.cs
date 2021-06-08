using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContactForm:EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Message { get; set; }


        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Emplyees Emplyees { get; set; }

        [Display(Name ="Country Name")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryName CountryNames { get; set; }


    }
}
