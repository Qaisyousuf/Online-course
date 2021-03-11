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
