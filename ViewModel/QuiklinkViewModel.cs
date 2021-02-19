using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class QuiklinkViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Icon Url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }

        [Required]
        [Display(Name ="LinkUrl")]
        public string LinkUrl { get; set; }
    }
}
