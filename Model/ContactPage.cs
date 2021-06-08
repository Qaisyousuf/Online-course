using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ContactPage:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name ="Contact Banner")]
        public int ContactBannerId { get; set; }

        [ForeignKey("ContactBannerId")]
        public ContactBanner ContactBanners { get; set; }

    }
}
