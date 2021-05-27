using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name="Program Name")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name="Country Flag")]
        public string CountryFlag { get; set; }


        [Display(Name = "Country Name")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryName CountryName { get; set; }
    }
}
