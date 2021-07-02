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

        public  List<WorkExperience> WorkExperiences { get; set; }
    }
}
