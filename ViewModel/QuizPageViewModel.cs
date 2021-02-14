using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class QuizPageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name ="Quiz Date Time")]
        public DateTime QuizDateTiem { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }
    }
}
