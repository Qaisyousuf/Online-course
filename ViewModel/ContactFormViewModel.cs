using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }


        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Mobile Number")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }


        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Emplyees Emplyees { get; set; }

        [Display(Name = "Country Name")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryName CountryNames { get; set; }
    }
}
