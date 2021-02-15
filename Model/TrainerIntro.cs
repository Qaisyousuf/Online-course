using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class TrainerIntro:EntityBase
    {
        public string Name { get; set; }

        public string AboutTrainer { get; set; }

        public string TrainerImageUrl { get; set; }

        public string TrainerAnimation { get; set; }

        public string TrainerLocation { get; set; }


    }
}
