using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class CountryNamesRepository:Repository<CountryName>,ICountryNamesRepository
    {
        public CountryNamesRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
