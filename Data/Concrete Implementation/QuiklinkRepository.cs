using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class QuiklinkRepository:Repository<Quiklink>,IQuiklinkRepository
    {
        public QuiklinkRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
