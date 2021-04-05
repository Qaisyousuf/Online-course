using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class QuizContentRepository:Repository<QuizContent>,IQuizContentRepository
    {
        public QuizContentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
