using Models;

namespace Data.Interfaces
{
    public interface IHomePageRepository:IRepository<HomePage>,ISlug
    {
        HomePage GetHomePageBySlug(string slug);
    }
}
