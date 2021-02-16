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
            WorkExperienceTags = new List<WorkExperienceTags>();
        }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AnimationUrl { get; set; }

        [Display(Name ="Tags Id")]
        public int TagsId { get; set; }

        [ForeignKey("TagsId")]
        public List<WorkExperienceTags> WorkExperienceTags { get; set; }


    }
}
