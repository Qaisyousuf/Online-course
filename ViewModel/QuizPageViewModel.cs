using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Quiz Basic info")]
        public int QuizBasicInfoID { get; set; }

        [ForeignKey("QuizBasicInfoID")]
        public QuizBasicInfo QuizBasicInfo { get; set; }
    }
}
