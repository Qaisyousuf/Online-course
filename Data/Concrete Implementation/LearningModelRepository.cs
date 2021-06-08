using Data.Interfaces;
using Models;
namespace Data.Concrete_Implementation
{
    public class LearningModelRepository:Repository<LearningModel>,ILearningModelRepository
    {
        public LearningModelRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
