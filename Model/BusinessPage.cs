using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BusinessPage:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name = "Business Banner")]
        public int BusinessBannerId { get; set; }

        [ForeignKey("BusinessBannerId")]
        public BusinessBanner BusinessBanner  { get; set; }
    }
}
