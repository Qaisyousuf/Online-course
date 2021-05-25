using Data.Interfaces;
using Model;
using System.Linq;

namespace Data.Concrete_Implementation
{
    public class ContactPageRepository:Repository<ContactPage>,IContactPageRepository
    {
        public ContactPageRepository(ApplicationDbContext context):base(context)
        {

        }

        public ContactPage GetContactPageBySlug(string slug)
        {
            return _context.ContactPages.Where(x =>x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.ContactPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.ContactPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
