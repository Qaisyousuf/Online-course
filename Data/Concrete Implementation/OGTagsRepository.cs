using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    class OGTagsRepository:Repository<OpenGraphMetaTags>,IOGTagsRepository
    {
        public OGTagsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
