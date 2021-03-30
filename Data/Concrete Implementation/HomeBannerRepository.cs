using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class HomeBannerRepository:Repository<HomeBanner>,IHomeBannerRepository
    {
        public HomeBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
