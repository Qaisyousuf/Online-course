using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ContactCounterViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        [Display(Name ="Counter Number")]
        public string CounterNumber { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }
    }
}
