using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ForLearner:EntityBase
    {
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }

    }
}
