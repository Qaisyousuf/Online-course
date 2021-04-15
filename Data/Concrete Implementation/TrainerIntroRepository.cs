using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class TrainerIntroRepository:Repository<TrainerIntro>,ITrainerIntroRepository
    {
        public TrainerIntroRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
