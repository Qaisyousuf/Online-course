using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class WorkExperienceTagsRepository:Repository<WorkExperienceTags>,IWorkExperienceTagsRepository
    {
        public WorkExperienceTagsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
