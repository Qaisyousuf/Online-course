using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuizPageRepository:Repository<QuizPage>,IQuizPageRepository
    {
        public QuizPageRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
