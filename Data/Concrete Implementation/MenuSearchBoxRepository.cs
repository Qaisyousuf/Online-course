using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class MenuSearchBoxRepository:Repository<MenuSearchBox>,IMenuSearchBoxRepository
    {
        public MenuSearchBoxRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
