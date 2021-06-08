using Data.Interfaces;
using Models;

namespace Data.Concrete_Implementation
{
    public class WhatTrainerLovesRepository:Repository<WhatTrainerLoves>,IWhatTrainerLovesRepository
    {
        public WhatTrainerLovesRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
