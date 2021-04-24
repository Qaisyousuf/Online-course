using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class CourseDescriptionRepository:Repository<CourseDescription>,ICourseDescriptionRepository
    {
        public CourseDescriptionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
