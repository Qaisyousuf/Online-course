using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TrainerVision:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ProfileImageUrl { get; set; }
        public string TrainerName { get; set; }
        public string BestRegards { get; set; }

    }
}
