using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class HowOnlineTrainingWorksRepository:Repository<HowOnlineTrainingWorks>,IHowOnlineTrainingWorksRepository
    {
        public HowOnlineTrainingWorksRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
