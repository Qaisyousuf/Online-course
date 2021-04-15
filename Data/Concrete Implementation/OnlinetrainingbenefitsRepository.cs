using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class OnlinetrainingbenefitsRepository:Repository<Onlinetrainingbenefits>,IOnlinetrainingbenefitsRepository
    {
        public OnlinetrainingbenefitsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
