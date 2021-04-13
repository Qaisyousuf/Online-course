using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class QuizResultsRepository:Repository<QuizResults>,IQuizResultsRepository
    {
        public QuizResultsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
