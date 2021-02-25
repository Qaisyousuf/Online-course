using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class BuillBetterSkillsFasterViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Ttile")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        public string AnimatinUrl { get; set; }
    }
}
