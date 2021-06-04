using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FooterLinksViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Navigation Name")]
        public string NavigationName { get; set; }

        [Required]
        [Display(Name ="Navigation Url")]
        public string LinkUrl { get; set; }

    }
}
