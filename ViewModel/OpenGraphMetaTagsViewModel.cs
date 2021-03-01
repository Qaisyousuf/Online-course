using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class OpenGraphMetaTagsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Tag Name or Property")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Tag Content")]
        public string Content { get; set; }
    }
}
