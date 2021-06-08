using Models;

namespace Data.Interfaces
{
    public interface IContactPageRepository:IRepository<ContactPage>,ISlug
    {
        ContactPage GetContactPageBySlug(string slug);
    }
}
