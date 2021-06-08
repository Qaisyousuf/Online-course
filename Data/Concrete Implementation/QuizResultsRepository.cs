using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuizResultsRepository:Repository<QuizResults>,IQuizResultsRepository
    {
        public QuizResultsRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
