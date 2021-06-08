using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class WhyOnlineTrainingIsImportantRepository:Repository<WhyOnlineTrainingIsImportant>,IWhyOnlineTrainingIsImportantRepository
    {
        public WhyOnlineTrainingIsImportantRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
