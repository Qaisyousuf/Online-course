using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class AboutPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name = "About Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public AboutBanner AboutBanners { get; set; }
    }
}
