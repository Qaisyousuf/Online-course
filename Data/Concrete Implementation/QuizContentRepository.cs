using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuizContentRepository:Repository<QuizContent>,IQuizContentRepository
    {
        public QuizContentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
