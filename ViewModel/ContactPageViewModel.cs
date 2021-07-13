using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class ContactPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }


        [Display(Name = "Contact Banner")]
        public int ContactBannerId { get; set; }

        [ForeignKey("ContactBannerId")]
        public ContactBanner ContactBanners { get; set; }
    }
}
