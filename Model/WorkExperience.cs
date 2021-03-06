using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class WorkExperience:EntityBase
    {
        public WorkExperience()
        {
            WorkExperTags = new List<WorkExperienceTags>();
        }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AnimationUrl { get; set; }

        public  List<WorkExperienceTags> WorkExperTags { get; set; }


    }
}
