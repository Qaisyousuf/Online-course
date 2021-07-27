using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class QuizBannerViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image url")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Join button")]
        public string JoinButton { get; set; }

        [Required]
        [Display(Name ="Join button url")]
        public string JoinButtonUrl { get; set; }

        [Required]
        [Display(Name ="Discover Button")]
        public string DiscoverButton { get; set; }

        [Required]
        [Display(Name ="Discover Button url")]
        public string DiscoverButtonTUrl { get; set; }
    }
}
