using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class TrainerIntroRepository:Repository<TrainerIntro>,ITrainerIntroRepository
    {
        public TrainerIntroRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
