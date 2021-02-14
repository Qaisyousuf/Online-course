using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class QuizQuestionViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Question Name")]
        public string QuestionsName { get; set; }

        [Required]
        [Display(Name = "Question Content")]
        public string QuestoinContent { get; set; }
    }
}
