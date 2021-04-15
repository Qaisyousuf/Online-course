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

        public ICourseContenntRepository CourseContenntRepository => new CourseContenntRepository(Context);

        public IQuizContentRepository QuizContentRepository => new QuizContentRepository(Context);

        public IQuizBasicInfoRepository QuizBasicInfoRepository => new QuizBasicInfoRepository(Context);

        public ICountryNamesRepository CountryNamesRepository => new CountryNamesRepository(Context);

        public IQuizQuestionRepository QuizQuestionRepository => new QuizQuestionRepository(Context);

        public IQuizResultsRepository QuizResultsRepository => new QuizResultsRepository(Context);

        public IHomePageRepository HomePageRepository => new HomePageRepository(Context);

        public IAboutBannerRepository AboutBannerRepository => new AboutBannerRepository(Context);

        public ITrainerIntroRepository TrainerIntroRepository => new TrainerIntroRepository(Context);

        public IOnlinetrainingbenefitsRepository OnlinetrainingbenefitsRepository => new OnlinetrainingbenefitsRepository(Context);

        public IUserbenefitsContentsRepository UserbenefitsContentsRepository => new UserbenefitsContentsRepository(Context);

        public IUserBenefitsSectionRepository UserBenefitsSectionRepository => new UserBenefitsSectionRepository(Context);

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
