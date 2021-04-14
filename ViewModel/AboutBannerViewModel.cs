using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AboutBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Join button")]
        public string JoinButton { get; set; }

        [Required]
        [Display(Name = "Join button url")]
        public string JoinButtonUrl { get; set; }

        [Required]
        [Display(Name = "Discover button")]
        public string DiscoverButton { get; set; }

        [Required]
        [Display(Name = "Discover button url")]
        public string DiscoverButtonUrl { get; set; }
    }
}
