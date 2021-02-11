using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountryNameViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Country Name")]
        public string LandName { get; set; }

    }
}
