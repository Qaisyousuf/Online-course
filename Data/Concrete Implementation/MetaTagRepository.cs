using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class MetaTagRepository:Repository<MetaTag>,IMetaTagRepository
    {
        public MetaTagRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
