using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class CourseEachSubSectionRepository:Repository<CourseEachSection>,ICourseSubSectionRepository
    {
        public CourseEachSubSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
