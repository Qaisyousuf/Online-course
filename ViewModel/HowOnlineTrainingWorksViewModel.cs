using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class HowOnlineTrainingWorksViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Video url")]
        [DataType(DataType.Url)]
        public string VideoUrl { get; set; }

        [Required]
        [Display(Name ="Animation url")]
        [DataType(DataType.Url)]
        public string AnimationUrl { get; set; }

        [Required]
        [Display(Name = "Logo IOS url")]
        [DataType(DataType.Url)]
        public string LogoUrlIOS { get; set; }

        [Required]
        [Display(Name = "Logo Android url")]
        [DataType(DataType.Url)]
        public string LogoUrlandroid { get; set; }

        [Required]
        [Display(Name = "Application button")]
        public string ApplicationDownloadButton { get; set; }

        [Required]
        [Display(Name = "Application Download url")]
        public string ApplicationDownloadUrl { get; set; }
    }
}
