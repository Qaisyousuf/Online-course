using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class AboutBannerRepository:Repository<AboutBanner>,IAboutBannerRepository
    {
        public AboutBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
