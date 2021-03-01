using Data.Interfaces;
using System;
using System.Linq;
using System.Data.Entity;

namespace Data.Concrete_Implementation
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext Context)
        {
            _context = Context;
        }
        public void Add(TModel entity)
        {
            _context.Set<TModel>().Add(entity);
        }

        public IQueryable<TModel> GetAll()
        {
            var data = _context.Set<TModel>();

            return data;
        }

        public TModel GetById(object Id)
        {
            return _context.Set<TModel>().Find(Id);
        }

        public void Remove(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
        }

        public void RemoveById(object Id)
        {
            TModel model = GetById(Id);

            if (model != null)
                Remove(model);
        }

        public void Update(TModel entity)
        {
            _context.Entry(entity).State =EntityState.Modified;

        }
    }
}
