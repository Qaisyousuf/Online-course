using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class BuildBetterSkillsFasterSectionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        public string IconUrl { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
