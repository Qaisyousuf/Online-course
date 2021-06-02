using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class MenuSearchBoxRepository:Repository<MenuSearchBox>,IMenuSearchBoxRepository
    {
        public MenuSearchBoxRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
