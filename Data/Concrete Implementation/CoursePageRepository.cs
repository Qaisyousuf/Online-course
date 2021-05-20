using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class CoursePageRepository:Repository<CoursePage>,ICoursePageRepository
    {
        public CoursePageRepository(ApplicationDbContext context):base(context)
        {

        }

        public CoursePage GetCoursePageBySlug(string slug)
        {
          return  _context.CoursePages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.CoursePages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.CoursePages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
