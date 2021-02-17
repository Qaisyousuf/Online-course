using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class TrainerSocialMediaViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name ="Profile Url")]
        public string SocialMediaProfileUrl { get; set; }

        [Required]
        [Display(Name = "Profile Icon Url")]
        public string SocialMediaIconUrl { get; set; }
    }
}
