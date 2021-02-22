using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ThankYouPageViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Contacted Info")]
        public string ContactedInfo { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        public string AnimatioUrl { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string ResponseEamil { get; set; }

        [Required]
        [Display(Name ="Home Button url")]
        public string HomeButtonUrl { get; set; }

        [Required]
        [Display(Name ="Home Button Text")]
        public string HomeButtonText { get; set; }

        [Required]
        [Display(Name ="Course Button Url")]
        public string CourseButtonUrl { get; set; }

        [Required]
        [Display(Name ="Course Button Text")]
        public string CourseButtonText { get; set; }
    }
}
