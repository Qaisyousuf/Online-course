using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class UpskillingImportanceViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Animation { get; set; }

        [Required]
        [Display(Name ="Registration Button")]
        public string RegisterButton { get; set; }

        [Required]
        [Display(Name ="Registration Button Url")]
        public string RegisterButtonUrl { get; set; }

        [Required]
        [Display(Name ="Contact Button")]
        public string ContactButton { get; set; }

        [Required]
        [Display(Name ="Contact Button url")]
        public string ContactButtonUrl { get; set; }
    }
}
