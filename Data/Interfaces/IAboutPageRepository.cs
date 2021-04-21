using Model;

namespace Data.Interfaces
{
    public interface IAboutPageRepository:IRepository<AboutPage>,ISlug
    {
        AboutPage GetAbouPageBySlug(string slug);
    }
}
