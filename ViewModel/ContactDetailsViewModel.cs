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

        [DataType(DataType.Date)]
        [Display(Name ="Start Date")]
        public DateTime WorkingStartDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name ="Start Time")]
        public DateTime WorkingStartTime { get; set; }



        [DataType(DataType.Date)]
        [Display(Name ="End Date")]
        public DateTime WrokingEndDate { get; set; }


        [DataType(DataType.Time)]
        [Display(Name ="End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        public string MapAnimationUrl { get; set; }
    }
}
