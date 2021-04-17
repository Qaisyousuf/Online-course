using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class WhyOnlineTrainingIsImportantViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Main Content")]
        public string MainContent { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Sub Content")]
        public string SubContent { get; set; }

        [Required]
        [Display(Name = "Icon url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }

        [Required]
        [Display(Name = "Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }
    }
}
