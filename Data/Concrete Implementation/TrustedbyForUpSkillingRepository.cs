using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class TrustedbyForUpSkillingRepository:Repository<TrustedbyForUpSkilling>,ITrustedbyForUpSkillingRepository
    {
        public TrustedbyForUpSkillingRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
