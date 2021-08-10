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

        public IWhoIsThisProgramForEachDetailsRepository WhoIsThisProgramForEachDetails => new WhoIsThisProgramForEachDetailsRepository(Context);

        public ILearningModelRepository LearningModelRepository => new LearningModelRepository(Context);

        public ICoursePageRepository CoursePageRepository => new CoursePageRepository(Context);

        public IContactBannerRepository ContactBannerRepository => new ContactBannerRepository(Context);

        public IContactDetailsRepository ContactDetailsRepository => new ContactDetailsRepository(Context);

        public IContactFormRepository ContactFormRepository => new ContactFormRepository(Context);

        public IEmployeesNumbersRepository EmployeesNumbersRepository => new EmployeesNumbersRepository(Context);

        public ISubscriptionSystemRepository SubscriptionSystemRepository => new SubscriptionSystemRepository(Context);

        public IContactPageRepository ContactpageRepository => new ContactPageRepository(Context);

        public IBusinessBannerRepository BusinessBannerRepository => new BusinessBannerRepository(Context);

        public IUpskillingImportanceRepository UpskillingImportanceRepository => new UpskillingImportanceRepository(Context);

        public IUpskillingExplorationRepository UpskillingExplorationRepository => new UpskillingExplorationRepository(Context);

        public ITrustedbyForUpSkillingRepository TrustedbyForUpSkillingRepository => new TrustedbyForUpSkillingRepository(Context);

        public IWhyYouNeedUpskillingYourTeamRepository WhyYouNeedUpskillingYourTeamRepository => new WhyYouNeedUpskillingYourTeamRepository(Context);

        public IWhyYouNeedUpSkillingYourTeamSectionRepository WhyYouNeedUpSkillingYourTeamSection => new WhyYouNeedUpSkillingYourTeamSectionRepository(Context);

        public IBuillBetterSkillsFasterRepository BuillBetterSkillsFasterRepository => new BuillBetterSkillsFasterRepository(Context);

        public IBuildBetterSkillsFasterSectionRepository BuildBetterSkillsFasterSectionRepository => new BuildBetterSkillsFasterSectionRepository(Context);

        public IGeolocationStudentsRepository GeolocationStudentsRepository => new GeolocationStudentsRepository(Context);

        public IUpSkillingEmployeesRepository UpSkillingEmployeesRepository => new UpSkillingEmployeesRepository(Context);

        public IITSkillsGapImpactsOnBusinessRepository ITSkillsGapImpactsOnBusiness => new ITSkillsGapImpactsOnBusinessRepository(Context);

        public IITGapSkillsSectionRepository ITGapSkillsSectionRepository => new ITGapSkillsSectionRepository(Context);

        public IBusinessPageRepository BusinessPageRepository => new BusinessPageRepository(Context);

        public IMetaTagRepository MetaTagRepository => new MetaTagRepository(Context);

        public IOGTagsRepository OGTagsRepository => new OGTagsRepository(Context);

        public ITwitterTagRepository TwitterTagRepository => new TwitterTagRepository(Context);

        public IMenuSearchBoxRepository MenuSearchBoxRepository => new MenuSearchBoxRepository(Context);

        public IMenuRepository MenuRepository => new MenuRepository(Context);

        public IFooterLinksRepository FooterLinksRepository => new FooterLinksRepository(Context);

        public ISiteSettingrepository SiteSettingrepository => new SiteSettingrepository(Context);

        public IOurVisionBannerRepository OurVisionBannerRepository => new OurVisionBannerRepository(Context);

        public IOurVisionExplortaionRepository OurVisionExplortaionRepository => new OurVisionExplortaionRepository(Context);

        public IQuizBannerRepository QuizBannerRepository => new QuizBannerRepository(Context);

        public IQuizPageRepository QuizPageRepository => new QuizPageRepository(Context);

        public IDashboardUserRepository DashboardUserRepository => new DashBoardRepository(Context);

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
