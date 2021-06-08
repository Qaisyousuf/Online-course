using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class BusinessPageRepository:Repository<BusinessPage>,IBusinessPageRepository
    {
        public BusinessPageRepository(ApplicationDbContext context):base(context)
        {

        }

        public BusinessPage GetBusinessPageBySlug(string slug)
        {
            return _context.BusinessPages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.BusinessPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.BusinessPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
