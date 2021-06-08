using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    class OGTagsRepository:Repository<OpenGraphMetaTags>,IOGTagsRepository
    {
        public OGTagsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
