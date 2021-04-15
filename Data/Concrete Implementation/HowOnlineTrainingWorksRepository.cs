using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class HowOnlineTrainingWorksRepository:Repository<HowOnlineTrainingWorks>,IHowOnlineTrainingWorksRepository
    {
        public HowOnlineTrainingWorksRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
