using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class QuizContentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name ="Quiz button")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name ="Quiz url")]
        public string ButtonUrl { get; set; }
    }
}
