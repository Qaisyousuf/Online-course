using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class ForLearnerRepository:Repository<ForLearner>,IForLearnerRepository
    {
        public ForLearnerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
