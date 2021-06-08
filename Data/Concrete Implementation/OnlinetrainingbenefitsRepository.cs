using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class OnlinetrainingbenefitsRepository:Repository<Onlinetrainingbenefits>,IOnlinetrainingbenefitsRepository
    {
        public OnlinetrainingbenefitsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
