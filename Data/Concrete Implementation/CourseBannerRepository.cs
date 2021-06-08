using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class CourseBannerRepository:Repository<CourseBanner>,ICourseBannerRepository
    {
        public CourseBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
