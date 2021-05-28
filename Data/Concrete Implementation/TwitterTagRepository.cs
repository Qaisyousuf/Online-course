using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class TwitterTagRepository:Repository<TwitterMetaTags>,ITwitterTagRepository
    {
        public TwitterTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
