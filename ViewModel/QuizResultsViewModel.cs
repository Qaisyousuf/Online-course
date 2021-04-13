using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class QuizResultsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name ="Recomandation")]
        public string ResultRecomandation { get; set; }

        [Required]
        [Display(Name ="Join Button")]
        public string JoinBtn { get; set; }

        [Required]
        [Display(Name ="Join Button Url")]
        public string JoinBtnUrl { get; set; }
    }
}
