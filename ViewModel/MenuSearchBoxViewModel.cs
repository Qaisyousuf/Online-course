using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class MenuSearchBoxViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Menu Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Url Addres")]
        public string Url { get; set; }
    }
}
