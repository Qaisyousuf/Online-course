using System.Collections.Generic;

namespace Models
{
    public class WorkExperienceTags:EntityBase
    {
        public WorkExperienceTags()
        {
            WorkExperiences = new List<WorkExperience>();
        }
        public string TagsName { get; set; }

        public  ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}
