using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
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
        public int? ParentId { get; set; }

        public Menus Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Menus> SubMenus { get; set; }

        

    }
}
