using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TrainerPhilosophyViewModel:BaseViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ProfileImageUrl { get; set; }
    }
}
