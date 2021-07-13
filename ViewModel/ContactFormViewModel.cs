using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ViewModel
{
    public class ContactFormViewModel:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name ="Name")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Mobile")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }


        
        [Display(Name ="Employees")]
        public int EmployeeId { get; set; }

       
        [ForeignKey("EmployeeId")]
        public Emplyees Emplyees { get; set; }


        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryName CountryNames { get; set; }
    }
}
