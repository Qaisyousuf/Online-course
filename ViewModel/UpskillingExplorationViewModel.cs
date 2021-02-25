using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class UpskillingExplorationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        public string IconUlr { get; set; }

    }
}
