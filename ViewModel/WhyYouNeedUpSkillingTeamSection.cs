using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WhyYouNeedUpSkillingTeamSection
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Icon Url")]
        public string IconUrl { get; set; }
    }
}
