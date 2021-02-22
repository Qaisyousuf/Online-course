using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ContactDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name ="Mobile")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Working Start Date")]
        public DateTime WorkingStartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Working End Date")]
        public DateTime WrokingEndDate { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
