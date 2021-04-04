using Data.Interfaces;

namespace Data.Concrete_Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        public ApplicationDbContext Context { get; }
        public UnitOfWork()
        {
            Context = new ApplicationDbContext();
        }

        public IHomeBannerRepository HomeBannerRepository
        {
            get { return new HomeBannerRepository(Context); }
        }

        public IHomeExplanationBannerRepository HomeExplanationBannerRepository
        {
            get { return new HomeExplanationBannerRepository(Context); }
        }

        public IForLearnerRepository ForLearnerRepository => new ForLearnerRepository(Context);

        public IOurVisionRepository OurVisionRepository => new OurVisionRepository(Context);

        public ICovid19Repository Covid19Repository => new Covid19Repository(Context);

        public ICourseSubSectionRepository CourseSubSectionRepository => new CourseEachSubSectionRepository(Context);

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
