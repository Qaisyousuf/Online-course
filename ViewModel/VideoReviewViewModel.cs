using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class VideoReviewViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Country flag url")]
        [DataType(DataType.Url)]
        public string CountryFlagUrl { get; set; }

        [Required]
        [Display(Name="Country Name")]
        public string CountryName { get; set; }

        [Required]
        [Display(Name="Video url")]
        [DataType(DataType.Url)]
        public string VideoUrl { get; set; }

        [Required]
        [Display(Name="Program Finish Date")]
        [DataType(DataType.Date)]
        public DateTime ProgramCompletionDate { get; set; }

        [Required]
        [Display(Name="Program Image Url")]
        public string ProgramImageUrl { get; set; }
    }
}
