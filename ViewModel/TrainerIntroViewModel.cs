using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class TrainerIntroViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="About Trainer")]
        public string AboutTrainer { get; set; }

        [Required]
        [Display(Name="Trainer Image url")]
        [DataType(DataType.Url)]
        public string TrainerImageUrl { get; set; }

        [Required]
        [Display(Name = "Trainer animation url")]
        [DataType(DataType.Url)]
        public string TrainerAnimation { get; set; }


        [Required]
        [Display(Name = "Trainer location")]
        
        public string TrainerLocation { get; set; }
    }
}
