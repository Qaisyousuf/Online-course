using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class WhoIsThisProgramForEachDetailsViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }
    }
}
