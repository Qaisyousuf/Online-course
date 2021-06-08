using Models;

namespace Data.Interfaces
{
    public interface IBusinessPageRepository:IRepository<BusinessPage>,ISlug
    {
        

        BusinessPage GetBusinessPageBySlug(string slug);
    }
}
