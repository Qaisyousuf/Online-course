using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class CourseDetailsRepository:Repository<CourseDetails>,ICourseDetailsRepository
    {
        public CourseDetailsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
