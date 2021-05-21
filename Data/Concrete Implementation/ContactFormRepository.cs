using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ContactFormRepository:Repository<ContactForm>,IContactFormRepository
    {
        public ContactFormRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
