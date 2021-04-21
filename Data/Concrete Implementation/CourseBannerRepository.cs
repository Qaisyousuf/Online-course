using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class CourseBannerRepository:Repository<CourseBanner>,ICourseBannerRepository
    {
        public CourseBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
