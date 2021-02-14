using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AboutBanner:EntityBase
    {
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string JoinButton { get; set; }
        public string JoinButtonUrl { get; set; }
        public string DiscoverButton { get; set; }
        public string DiscoverButtonTUrl { get; set; }
    }
}
