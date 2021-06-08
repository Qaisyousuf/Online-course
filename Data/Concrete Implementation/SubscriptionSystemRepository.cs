using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class SubscriptionSystemRepository:Repository<SubscriptionSystem>,ISubscriptionSystemRepository
    {
        public SubscriptionSystemRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
