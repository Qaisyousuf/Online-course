using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class CourseContenntRepository:Repository<CourseContents>,ICourseContenntRepository
    {
        public CourseContenntRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
