using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ContactBannerRepository:Repository<ContactBanner>,IContactBannerRepository
    {
        public ContactBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
