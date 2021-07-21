using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class TrustedbyForUpSkillingViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }

        [Required]
        [Display(Name ="Logo Url")]
        [DataType(DataType.Url)]
        public string LogoUrl { get; set; }
    }
}
