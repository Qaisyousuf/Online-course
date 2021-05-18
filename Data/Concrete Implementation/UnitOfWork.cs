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

        public IHowOnlineTrainingWorksRepository HowOnlineTrainingWorksRepository => new HowOnlineTrainingWorksRepository(Context);

        public ISubscriptionContentRepository SubscriptionContentRepository => new SubscriptionContentRepository(Context);

        public IWhyOnlineTrainingIsImportantRepository WhyOnlineTrainingIsImportantRepository => new WhyOnlineTrainingIsImportantRepository(Context);

        public IStudentsSaysRepository StudentsSaysRepository => new StudentsSaysRepository(Context);

        public IVideoReviewRepository VideoReviewRepository => new VideoReviewRepository(Context);

        public IWhatTrainerLovesRepository WhatTrainerLovesRepository => new WhatTrainerLovesRepository(Context);

        public IWorkExperienceRepository WorkExperienceRepository => new WorkExperienceRepository(Context);

        public IWorkExperienceTagsRepository WorkExperienceTagsRepository =>new  WorkExperienceTagsRepository(Context);

        public ITrainerPhilosophyRepository TrainerPhilosophyRepository => new TrainerPhilosophyRepository(Context);

        public ITrainerVisionRepository TrainerVisionRepository => new TrainerVisionRepository(Context);

        public ITrainerSocialMediaRepository TrainerSocialMediaRepository => new TrainerSocialMediaRepository(Context);

        public IAboutPageRepository AboutPageRepository => new AboutPageRepository(Context);

        public ICourseBannerRepository CourseBannerRepository =>new CourseBannerRepository(Context);

        public ICourseContentExplanationRepository CourseContentExplanationRepository => new CourseContentExplanationRepository(Context);

        public ICourseDetailsRepository CourseDetailsRepository => new CourseDetailsRepository(Context);

        public ICourseDescriptionRepository CourseDescriptionRepository => new CourseDescriptionRepository(Context);

        public IYouMayLikeRepository YouMayLikeRepository => new YouMayLikeRepository(Context);

        public ILaunchYourCodingCareerRepository launchYourCoding => new LaunchYourCodingCareerRepository(Context);

        public IQuiklinkRepository QuiklinkRepository => new QuiklinkRepository(Context);

        public IThisProgramForWhoContentSectionRepository ThisProgramForWhoContentSectionRepository => new ThisProgramForWhoContentSectionRepository(Context);

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
