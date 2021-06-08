using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class TwitterTagRepository:Repository<TwitterMetaTags>,ITwitterTagRepository
    {
        public TwitterTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
