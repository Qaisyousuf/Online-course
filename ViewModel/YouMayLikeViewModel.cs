using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class YouMayLikeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Contetn { get; set; }

        [Required]
        [Display(Name ="Image url")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}
