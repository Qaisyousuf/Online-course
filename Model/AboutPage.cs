using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class AboutPage:EntityBase
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name ="About Banner")]
        public int BannerId { get; set; }

        [ForeignKey("BannerId")]
        public AboutBanner AboutBanners { get; set; }

    }
}
