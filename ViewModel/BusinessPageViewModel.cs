using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class BusinessPageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }


        [Display(Name = "Business Banner")]
        public int BusinessBannerId { get; set; }

        [ForeignKey("BusinessBannerId")]
        public BusinessBanner BusinessBanner { get; set; }
    }
}
