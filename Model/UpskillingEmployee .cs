using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UpskillingEmployee:EntityBase
    {
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string TalkToExpertButton { get; set; }
        public string TalkToExpertButtonUrl { get; set; }
        public string IllstrationUrl { get; set; }

    }
}
