using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class UpskillingImportanceRepository:Repository<UpskillingImportance>,IUpskillingImportanceRepository
    {
        public UpskillingImportanceRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
