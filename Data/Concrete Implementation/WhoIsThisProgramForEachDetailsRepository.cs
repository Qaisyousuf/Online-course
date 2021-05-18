using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class WhoIsThisProgramForEachDetailsRepository:Repository<WhoIsThisProgramForEachDetails>,IWhoIsThisProgramForEachDetailsRepository
    {
        public WhoIsThisProgramForEachDetailsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
