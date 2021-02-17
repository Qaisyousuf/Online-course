using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class TrainerVisionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Profile Image Url")]
        [DataType(DataType.Url)]
        public string ProfileImageUrl { get; set; }

        [Required]
        [Display(Name ="Trainer Name")]
        public string TrainerName { get; set; }

        [Required]
        [Display(Name = "Best Regards")]
        public string BestRegards { get; set; }
    }
}
