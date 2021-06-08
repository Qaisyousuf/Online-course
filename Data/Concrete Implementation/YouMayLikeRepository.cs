using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class YouMayLikeRepository:Repository<YouMayLike>,IYouMayLikeRepository
    {
        public YouMayLikeRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
