using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ThankYouPage:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContactedInfo { get; set; }
        public string AnimatioUrl { get; set; }
        public string ResponseEamil { get; set; }
        public string HomeButtonUrl { get; set; }
        public string HomeButtonText { get; set; }
        public string CourseButtonUrl { get; set; }
        public string CourseButtonText { get; set; }

    }
}
