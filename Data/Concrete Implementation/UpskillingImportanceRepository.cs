using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class UpskillingImportanceRepository:Repository<UpskillingImportance>,IUpskillingImportanceRepository
    {
        public UpskillingImportanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
