using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class SubscriptionContentRepository:Repository<SubscriptionContent>,ISubscriptionContentRepository
    {
        public SubscriptionContentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
