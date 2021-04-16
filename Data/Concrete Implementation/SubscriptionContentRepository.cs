using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class SubscriptionContentRepository:Repository<SubscriptionContent>,ISubscriptionContentRepository
    {
        public SubscriptionContentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
