using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class WhyOnlineTrainingIsImportantRepository:Repository<WhyOnlineTrainingIsImportant>,IWhyOnlineTrainingIsImportantRepository
    {
        public WhyOnlineTrainingIsImportantRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
