using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class FooterLinksRepository:Repository<FooterLinks>,IFooterLinksRepository
    {
        public FooterLinksRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
