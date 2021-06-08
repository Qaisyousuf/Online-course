using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CourseDescription:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TakeCourseButton { get; set; }
        public string TakeCourseButtonUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}
