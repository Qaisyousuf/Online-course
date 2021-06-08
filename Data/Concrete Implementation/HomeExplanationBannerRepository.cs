using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class HomeExplanationBannerRepository:Repository<HomeExplorationBanner>,IHomeExplanationBannerRepository
    {
        public HomeExplanationBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
