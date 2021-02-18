using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseContents:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AnimationUrl { get; set; }


    }
}
