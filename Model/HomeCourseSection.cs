using System;

namespace Models
{
    public class HomeCourseSection:EntityBase
    {
        public string MainTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string NumberofView { get; set; }
        public string RedMoreButton { get; set; }

    }
}
