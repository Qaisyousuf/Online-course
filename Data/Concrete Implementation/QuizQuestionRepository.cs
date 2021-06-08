using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuizQuestionRepository:Repository<QuizQuestion>,IQuizQuestionRepository
    {
        public QuizQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
