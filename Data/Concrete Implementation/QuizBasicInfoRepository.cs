using Data.Interfaces;
using Models;


namespace Data.Concrete_Implementation
{
    public class QuizBasicInfoRepository:Repository<QuizBasicInfo>,IQuizBasicInfoRepository
    {
        public QuizBasicInfoRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
