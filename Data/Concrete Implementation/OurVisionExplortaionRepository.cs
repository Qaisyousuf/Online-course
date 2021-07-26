using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class OurVisionExplortaionRepository:Repository<OurVisionExplation>,IOurVisionExplortaionRepository
    {
        public OurVisionExplortaionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
