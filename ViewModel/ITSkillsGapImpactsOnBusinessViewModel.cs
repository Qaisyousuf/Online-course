using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ITSkillsGapImpactsOnBusinessViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Get In Touch")]
        public string Button { get; set; }

        [Required]
        [Display(Name = "Get In Touch Url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        public string AnimationUrl { get; set; }
    }
}
