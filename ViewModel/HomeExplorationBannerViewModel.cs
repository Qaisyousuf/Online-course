using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class HomeExplorationBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }
    }
}
