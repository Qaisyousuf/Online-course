using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ContactDetailsRepository:Repository<ContactDetails>,IContactDetailsRepository
    {
        public ContactDetailsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
