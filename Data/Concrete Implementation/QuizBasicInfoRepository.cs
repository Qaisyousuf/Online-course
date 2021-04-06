using Data.Interfaces;
using Model;


namespace Data.Concrete_Implementation
{
    public class QuizBasicInfoRepository:Repository<QuizBasicInfo>,IQuizBasicInfoRepository
    {
        public QuizBasicInfoRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
