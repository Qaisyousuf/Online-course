using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class ClassDataRepository:Repository<ClassData>,IClassDataRepository
    {
        public ClassDataRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
