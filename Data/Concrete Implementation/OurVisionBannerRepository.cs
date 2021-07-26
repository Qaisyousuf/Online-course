using Data.Interfaces;
using Models;
namespace Data.Concrete_Implementation
{
    public class OurVisionBannerRepository:Repository<OurVisionBanner>,IOurVisionBannerRepository
    {
        public OurVisionBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
