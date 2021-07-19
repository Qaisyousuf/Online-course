using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CourseDescriptionViewModel:BaseViewModel
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
        [Display(Name ="Take Course Button")]
        public string TakeCourseButton { get; set; }

        [Required]
        [Display(Name ="Take course button url")]
        public string TakeCourseButtonUrl { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}
