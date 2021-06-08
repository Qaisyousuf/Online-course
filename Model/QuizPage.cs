using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class QuizPage:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime QuizDateTiem { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }


        [Display(Name ="Quiz Basic info")]
        public int QuizBasicInfoID { get; set; }

        [ForeignKey("QuizBasicInfoID")]
        public QuizBasicInfo QuizBasicInfo { get; set; }

    }
}
