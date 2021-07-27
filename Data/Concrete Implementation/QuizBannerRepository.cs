using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuizBannerRepository:Repository<QuizBanner>,IQuizBannerRepository
    {
        public QuizBannerRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
