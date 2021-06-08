using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class MetaTagRepository:Repository<MetaTag>,IMetaTagRepository
    {
        public MetaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
