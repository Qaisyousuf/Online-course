using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseEachSection:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Duration { get; set; }
        public string ReadMoreButton { get; set; }
        public string ReadMoreButtonUrl { get; set; }
        public string DownloadCurriculumButton { get; set; }
        public string DwonloadCurriculumText { get; set; }


    }
}
