using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class OurVisionRepository:Repository<OurVision>,IOurVisionRepository
    {
        public OurVisionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
