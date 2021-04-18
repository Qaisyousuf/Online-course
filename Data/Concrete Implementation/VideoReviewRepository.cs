using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class VideoReviewRepository:Repository<VideoReview>,IVideoReviewRepository
    {
        public VideoReviewRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
