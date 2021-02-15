using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class SubscriptionContentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subscription Content")]
        public string SubContent { get; set; }

        [Required]
        [Display(Name = "Subscription Main Content")]
        public string MainContent { get; set; }

        [Required]
        [Display(Name = "Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }
    }
}
