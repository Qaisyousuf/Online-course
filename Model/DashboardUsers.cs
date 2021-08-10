using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DashboardUsers:EntityBase
    {
        public string Title { get; set; }
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string AnimationLink { get; set; }
        public ApplicationUser AdminUsers { get; set; }


    }
}
