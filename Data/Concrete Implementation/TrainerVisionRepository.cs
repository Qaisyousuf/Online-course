using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public  class TrainerVisionRepository:Repository<TrainerVision>,ITrainerVisionRepository
    {
        public TrainerVisionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
