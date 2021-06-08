using Models;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class CourseContentExplanationRepository:Repository<CourseContentExplanation>,ICourseContentExplanationRepository
    {
        public CourseContentExplanationRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
