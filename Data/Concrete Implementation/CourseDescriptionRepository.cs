using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class CourseDescriptionRepository:Repository<CourseDescription>,ICourseDescriptionRepository
    {
        public CourseDescriptionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
