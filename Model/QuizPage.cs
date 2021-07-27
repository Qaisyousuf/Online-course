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
       
        [Display(Name ="Quiz")]
        public int QuizBannerId { get; set; }

        [ForeignKey("QuizBannerId")]
        public QuizBanner QuizBanners { get; set; }

    }
}
