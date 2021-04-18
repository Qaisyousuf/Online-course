using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
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


        public  ICollection<WorkExperienceTags> WorkExperTags { get; set; }


    }
}
