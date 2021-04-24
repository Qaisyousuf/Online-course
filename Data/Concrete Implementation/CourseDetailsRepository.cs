using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class CourseDetailsRepository:Repository<CourseDetails>,ICourseDetailsRepository
    {
        public CourseDetailsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
