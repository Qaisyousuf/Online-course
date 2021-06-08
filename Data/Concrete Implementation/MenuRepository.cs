using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class MenuRepository:Repository<Menus>,IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
