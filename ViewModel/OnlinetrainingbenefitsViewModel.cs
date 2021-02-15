using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class OnlinetrainingbenefitsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "sub title")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }
    }
}
