using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<TModel> where TModel:class
    {
        void Add(TModel entity);

        void Update(TModel entity);

        IQueryable<TModel> GetAll();

        TModel GetById(object Id);

        void Remove(TModel entity);

        void RemoveById(object Id);
    }
}
