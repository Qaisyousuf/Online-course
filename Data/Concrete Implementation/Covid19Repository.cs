using Data.Interfaces;
using Models;
namespace Data.Concrete_Implementation
{
    class Covid19Repository:Repository<COVID_19>,ICovid19Repository
    {
        public Covid19Repository(ApplicationDbContext context):base(context)
        {

        }
    }
}
