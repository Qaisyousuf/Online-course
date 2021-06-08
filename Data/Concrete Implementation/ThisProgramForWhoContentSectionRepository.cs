using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ThisProgramForWhoContentSectionRepository:Repository<WhoIsThisProgramForContentSection>,IThisProgramForWhoContentSectionRepository
    {
        public ThisProgramForWhoContentSectionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
