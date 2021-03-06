using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class MenusViewModel
    {
        public MenusViewModel()
        {
            SubMenus = new List<Menus>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        [Display(Name ="Sub Menus")]
        public int? ParentId { get; set; }

        public Menus Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menus> SubMenus { get; set; }
    }
}
