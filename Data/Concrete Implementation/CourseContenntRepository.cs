using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class CourseContenntRepository:Repository<CourseContents>,ICourseContenntRepository
    {
        public CourseContenntRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
