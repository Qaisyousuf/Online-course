using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HowOnlineTrainingWorks:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public string AnimationUrl { get; set; }
        public string LogoUrlIOS { get; set; }
        public string LogoUrlandroid { get; set; }
        public string ApplicationDownloadButton { get; set; }
        public string ApplicationDownloadUrl { get; set; }

    }
}
