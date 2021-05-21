using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ContactDetailsRepository:Repository<ContactDetails>,IContactDetailsRepository
    {
        public ContactDetailsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
