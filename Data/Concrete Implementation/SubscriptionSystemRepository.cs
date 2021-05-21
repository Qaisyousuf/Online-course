using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class SubscriptionSystemRepository:Repository<SubscriptionSystem>,ISubscriptionSystemRepository
    {
        public SubscriptionSystemRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
