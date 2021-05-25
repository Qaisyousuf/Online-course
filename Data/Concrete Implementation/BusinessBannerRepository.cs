using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class BusinessBannerRepository:Repository<BusinessBanner>,IBusinessBannerRepository
    {
        public BusinessBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
