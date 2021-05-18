using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
   public class WhoIsThisProgramForContentSectionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Video Url")]
        [DataType(DataType.Url)]
        public string VideoUrl { get; set; }

        [Required]
        [Display(Name ="Read more")]
        public string ReadMoreButton { get; set; }

        [Required]
        [Display(Name ="Read more url")]
        public string ReadMoreButtonUrl { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationContent { get; set; }
    }
}
