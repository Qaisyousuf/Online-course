using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class HomeBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Main Subtitle")]
        public string SubMaintitle { get; set; }

        [Required]
        [Display(Name ="Content")]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Join button")]
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
