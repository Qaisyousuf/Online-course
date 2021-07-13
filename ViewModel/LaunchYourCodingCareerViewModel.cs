using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class LaunchYourCodingCareerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Video url")]
        public string VideoUrl { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }

        [Required]
        [Display(Name ="Registration button")]
        public string RegisterButton { get; set; }

        [Required]
        [Display(Name ="Registration button url")]
        public string RegisterButtonUrl { get; set; }

        [Required]
        [Display(Name ="Take course button")]
        public string TakeCourseButton { get; set; }

        [Required]
        [Display(Name ="Take course url")]
        public string TakeCourseButtonUrl { get; set; }
    }
}
