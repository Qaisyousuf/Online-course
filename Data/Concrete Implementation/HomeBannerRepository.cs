using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class HomeBannerRepository:Repository<HomeBanner>,IHomeBannerRepository
    {
        public HomeBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
