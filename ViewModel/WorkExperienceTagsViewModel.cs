using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorkExperienceTagsViewModel
    {
        public WorkExperienceTagsViewModel()
        {
            WorkExperiences = new List<WorkExperience>();
        }
        public int Id { get; set; }

        public string TagsName { get; set; }

        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
