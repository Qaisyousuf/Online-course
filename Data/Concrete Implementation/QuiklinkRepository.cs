using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class QuiklinkRepository:Repository<Quiklink>,IQuiklinkRepository
    {
        public QuiklinkRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
