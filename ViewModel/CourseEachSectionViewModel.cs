using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseEachSectionViewModel
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
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [Display(Name ="Read more button")]
        public string ReadMoreButton { get; set; }

        [Required]
        [Display(Name ="Read more button url")]
        public string ReadMoreButtonUrl { get; set; }

        [Required]
        [Display(Name ="Download curriculum")]
        public string DownloadCurriculumButton { get; set; }

        [Required]
        [Display(Name ="Download curriculum text")]
        public string DwonloadCurriculumText { get; set; }
    }
}
