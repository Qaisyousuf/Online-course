using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class EmployeesNumbersRepository:Repository<Emplyees>,IEmployeesNumbersRepository
    {
        public EmployeesNumbersRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
