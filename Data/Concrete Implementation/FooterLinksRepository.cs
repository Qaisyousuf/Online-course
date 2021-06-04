using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class FooterLinksRepository:Repository<FooterLinks>,IFooterLinksRepository
    {
        public FooterLinksRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
