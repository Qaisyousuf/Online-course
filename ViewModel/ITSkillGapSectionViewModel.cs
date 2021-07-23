using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ITSkillGapSectionViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string Subcontent { get; set; }

        [Required]
        [Display(Name ="Animation Url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }

        [Required]
        [Display(Name ="Contact Us")]
        public string Button { get; set; }

        [Required]
        [Display(Name ="Button Url")]
        public string ButtonUrl { get; set; }
    }
}
