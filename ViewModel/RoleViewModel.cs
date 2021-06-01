using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Display(Name="Role Name")]
        public string Name { get; set; }

    }
}
