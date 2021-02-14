using System;
using System.Collections.Generic;

namespace Model
{
    public class QuizPage:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime QuizDateTiem { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; }

    }
}
