using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ViewModel
{
    public class UserContactViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [AllowHtml]
        public string Message { get; set; }

        [Display(Name ="Contact By")]
        public string ContactBy { get; set; }

        [Display(Name ="Contact Email")]
        public string ContactEmail { get; set; }

        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }
    }
}
