using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class HomeCourseSectionViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Content")]
        public string Content { get; set; }

        [Display(Name ="View")]
        public string NumberofView { get; set; }

        [Required]
        [Display(Name ="Explor button")]
        public string RedMoreButton { get; set; }

    }
}
