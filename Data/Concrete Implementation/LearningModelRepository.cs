using Data.Interfaces;
using Model;
namespace Data.Concrete_Implementation
{
    public class LearningModelRepository:Repository<LearningModel>,ILearningModelRepository
    {
        public LearningModelRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
