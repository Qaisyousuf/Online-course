using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModel
{
    public class QuizPageViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Quiz")]
        public int QuizBannerId { get; set; }

        [ForeignKey("QuizBannerId")]
        public QuizBanner QuizBanners { get; set; }
    }
}
