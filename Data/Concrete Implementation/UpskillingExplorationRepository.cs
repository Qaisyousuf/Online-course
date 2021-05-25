using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class UpskillingExplorationRepository:Repository<UpskillingExploration>,IUpskillingExplorationRepository
    {
        public UpskillingExplorationRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
