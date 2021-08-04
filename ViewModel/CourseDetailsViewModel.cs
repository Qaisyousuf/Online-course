using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CourseDetailsViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Sub Content")]
        public string SubContents { get; set; }

        [Required]
        [Display(Name ="Register Button")]
        public string RegisterButton { get; set; }

        [Required]
        [Display(Name ="Register Button Url")]
        public string RegisterButtonUrl { get; set; }

        [Required]
        [Display(Name ="Life time Access")]
        public string LifeTimeAccess { get; set; }

        [Required]
        [Display(Name ="Course Type")]
        public string CourseType { get; set; }

        [Required]
        [Display(Name ="Number of articales")]
        public string NumArticales { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [Display(Name ="Program Title")]
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
