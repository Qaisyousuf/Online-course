using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseBannerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        [Display(Name ="Sub Title")]
        public string SubTitle { get; set; }

        [Required]
        [Display(Name ="Image Url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Join Button")]
        public string JoinButton { get; set; }

        [Required]
        [Display(Name ="join Button Url")]
        public string JoinButtonUrl { get; set; }

        [Required]
        [Display(Name ="Discover Button")]
        public string DiscoverButton { get; set; }

        [Required]
        [Display(Name ="Discover url")]
        public string DiscoverButtonTUrl { get; set; }
    }
}
