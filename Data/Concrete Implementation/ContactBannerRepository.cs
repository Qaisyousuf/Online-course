using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ContactBannerRepository:Repository<ContactBanner>,IContactBannerRepository
    {
        public ContactBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
