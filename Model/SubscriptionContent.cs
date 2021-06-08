using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SubscriptionContent:EntityBase
    {
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string MainContent { get; set; }
        public string AnimationUrl { get; set; }

    }
}
