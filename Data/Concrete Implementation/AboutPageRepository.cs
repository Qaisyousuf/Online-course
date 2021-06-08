using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
   public class AboutPageRepository:Repository<AboutPage>,IAboutPageRepository
    {
        public AboutPageRepository(ApplicationDbContext context):base(context)
        {

        }

        public AboutPage GetAbouPageBySlug(string slug) => _context.AboutPages.Where(x => x.Slug == slug).SingleOrDefault();

        public bool SlugExists(string slug) => _context.AboutPages.Any(x => x.Slug == slug);

        public bool SlugExists(int? id, string slug) => _context.AboutPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
    }
}
