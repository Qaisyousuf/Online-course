using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class OurVisionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }
        
        [Required]
        [Display(Name ="Button Text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name = "Button url")]
        public string ButtonUrl { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}
