using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class TrainerSocialMediaRepository:Repository<TrainerSocialMedia>,ITrainerSocialMediaRepository
    {
        public TrainerSocialMediaRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
