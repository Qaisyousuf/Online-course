using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ForLearnerRepository:Repository<ForLearner>,IForLearnerRepository
    {
        public ForLearnerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
