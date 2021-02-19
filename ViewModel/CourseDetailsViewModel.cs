using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [Display(Name ="Course Title")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name ="Videio Language")]
        public string VideoLanguage { get; set; }

        [Required]
        [Display(Name ="Trainer Name")]
        public string Trainer { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Certification")]
        public string Certification { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Availability { get; set; }

        [Required]
        [Display(Name ="Students Finished")]
        public string SutdentFinished { get; set; }
    }
}
