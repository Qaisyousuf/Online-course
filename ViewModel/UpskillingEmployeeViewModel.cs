using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UpskillingEmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Talk To Expert")]
        public string TalkToExpertButton { get; set; }

        [Required]
        [Display(Name ="Talk To Expert Url")]
        public string TalkToExpertButtonUrl { get; set; }

        [Required]
        [Display(Name ="Illstration Url")]
        public string IllstrationUrl { get; set; }

    }
}
