using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public  class TrainerVisionRepository:Repository<TrainerVision>,ITrainerVisionRepository
    {
        public TrainerVisionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
