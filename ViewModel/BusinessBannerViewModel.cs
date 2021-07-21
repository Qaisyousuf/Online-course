using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class BusinessBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Sub Content")]
        public string SubContent { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Join Button")]
        public string JoinButton { get; set; }

        [Required]
        [Display(Name = "join Button Url")]
        public string JoinButtonUrl { get; set; }

        [Required]
        [Display(Name = "Discover Button")]
        public string DiscoverButton { get; set; }

        [Required]
        [Display(Name = "Discover url")]
        public string DiscoverButtonTUrl { get; set; }
    }
}
