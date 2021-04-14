using Data.Interfaces;
using Model;
using System.Linq;

namespace Data.Concrete_Implementation
{
    public class HomePageRepository:Repository<HomePage>,IHomePageRepository
    {
        public HomePageRepository(ApplicationDbContext context):base(context)
        {
           
        }

        public HomePage GetHomePageBySlug(string slug)
        {
            return _context.HomePages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.HomePages.Any(x => x.Slug == slug);
           
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.HomePages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
