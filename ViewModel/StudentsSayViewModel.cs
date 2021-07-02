using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudentsSayViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Program Name")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }


        [Required]
        [Display(Name ="Pic Url")]
        public string PicUrl { get; set; }

        [Required]
        [Display(Name ="Country Name")]
        public string CountryName { get; set; }
    }
}
