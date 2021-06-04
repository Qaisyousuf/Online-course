using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class MenuRepository:Repository<Menus>,IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
