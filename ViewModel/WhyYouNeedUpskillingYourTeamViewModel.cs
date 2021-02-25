using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class WhyYouNeedUpskillingYourTeamViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name ="AnimationUrl")]
        public string AnimationUrl { get; set; }
    }
}
