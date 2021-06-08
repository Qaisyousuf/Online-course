using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Menus:EntityBase
    {
        public Menus()
        {
            SubMenus = new List<Menus>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [InverseProperty("SubMenus")]
        public int? ParentId { get; set; }

        public Menus Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menus> SubMenus { get; set; }

        

    }
}
