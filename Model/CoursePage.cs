using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CoursePage:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name ="Banner")]
        public int CourseBannerId { get; set; }

        [ForeignKey("CourseBannerId")]
        public CourseBanner CourseBanner { get; set; }

    }
}
