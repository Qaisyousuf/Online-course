using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class COVID_19ViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Covid button text")]
        public string CovidButtonText { get; set; }

        [Required]
        [Display(Name ="Covid button url")]
        public string CovidButtonUrl { get; set; }

        [Required]
        [Display(Name ="Course button text")]
        public string CourseButtonText { get; set; }

        [Required]
        [Display(Name ="Course button url")]
        public string CourseButtonUrl { get; set; }
    }
}
