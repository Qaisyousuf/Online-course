using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class YouMayLikeRepository:Repository<YouMayLike>,IYouMayLikeRepository
    {
        public YouMayLikeRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
