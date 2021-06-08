using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
   public  class TrainerPhilosophyRepository:Repository<TrainerPhilosophy>,ITrainerPhilosophyRepository
    {
        public TrainerPhilosophyRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
