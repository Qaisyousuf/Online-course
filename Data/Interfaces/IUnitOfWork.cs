using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationDbContext Context { get; }

        IHomeBannerRepository HomeBannerRepository { get; }
        IHomeExplanationBannerRepository HomeExplanationBannerRepository { get; }
        IForLearnerRepository ForLearnerRepository { get; }
        IOurVisionRepository OurVisionRepository { get; }
        ICovid19Repository Covid19Repository { get; }

        void Commit();
    }
}
