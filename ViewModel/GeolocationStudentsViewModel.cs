using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class GeolocationStudentsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [Display(Name="Program Name")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name="Country Flag")]
        public string CountryFlag { get; set; }
    }
}
