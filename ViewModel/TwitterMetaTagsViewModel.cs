using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class TwitterMetaTagsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Tag Name or property")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Tag Content")]
        public string Content { get; set; }
    }
}
