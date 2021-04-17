using Data.Interfaces;
using Model;

namespace Data.Concrete_Implementation
{
    public class StudentsSaysRepository:Repository<StudentsSay>,IStudentsSaysRepository
    {
        public StudentsSaysRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
