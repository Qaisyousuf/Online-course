using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class UserbenefitsContentsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string Maintitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Sign Up")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name ="Sign Up url")]
        public string ButtonUrl { get; set; }
    }
}
