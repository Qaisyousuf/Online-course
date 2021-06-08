using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class VideoReviewRepository:Repository<VideoReview>,IVideoReviewRepository
    {
        public VideoReviewRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
