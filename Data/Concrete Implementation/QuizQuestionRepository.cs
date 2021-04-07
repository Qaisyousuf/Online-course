using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class QuizQuestionRepository:Repository<QuizQuestion>,IQuizQuestionRepository
    {
        public QuizQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
