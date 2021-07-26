using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class OurVisionExplationViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}
