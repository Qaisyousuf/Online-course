using System;

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
        ICourseSubSectionRepository CourseSubSectionRepository { get; }
        ICourseContenntRepository CourseContenntRepository { get; }
        IQuizContentRepository QuizContentRepository { get; }
        IQuizBasicInfoRepository QuizBasicInfoRepository { get; }
        ICountryNamesRepository CountryNamesRepository { get; }
        IQuizQuestionRepository QuizQuestionRepository { get; }
        IQuizResultsRepository QuizResultsRepository { get; }
        IHomePageRepository HomePageRepository { get; }
        IAboutBannerRepository AboutBannerRepository { get; }
        ITrainerIntroRepository TrainerIntroRepository { get; }
        IOnlinetrainingbenefitsRepository OnlinetrainingbenefitsRepository { get; }
        IUserbenefitsContentsRepository UserbenefitsContentsRepository { get; }
        IUserBenefitsSectionRepository UserBenefitsSectionRepository { get; }
        IHowOnlineTrainingWorksRepository HowOnlineTrainingWorksRepository { get; }
        ISubscriptionContentRepository SubscriptionContentRepository { get; }
        IWhyOnlineTrainingIsImportantRepository WhyOnlineTrainingIsImportantRepository { get; }
        IStudentsSaysRepository StudentsSaysRepository { get; } 
        IVideoReviewRepository VideoReviewRepository { get; }
        IWhatTrainerLovesRepository WhatTrainerLovesRepository { get; }
        IWorkExperienceRepository WorkExperienceRepository { get; }
        IWorkExperienceTagsRepository WorkExperienceTagsRepository { get; }
        ITrainerPhilosophyRepository TrainerPhilosophyRepository { get; }
        ITrainerVisionRepository TrainerVisionRepository { get; }
        ITrainerSocialMediaRepository TrainerSocialMediaRepository { get; }
        IAboutPageRepository AboutPageRepository { get; }
        ICourseBannerRepository CourseBannerRepository { get; }
        ICourseContentExplanationRepository CourseContentExplanationRepository { get; }
        ICourseDetailsRepository CourseDetailsRepository { get; }
        ICourseDescriptionRepository CourseDescriptionRepository { get; }
        IYouMayLikeRepository YouMayLikeRepository { get; }
        ILaunchYourCodingCareerRepository launchYourCoding { get; }
        IQuiklinkRepository QuiklinkRepository { get; }
        IThisProgramForWhoContentSectionRepository ThisProgramForWhoContentSectionRepository { get; }
        IWhoIsThisProgramForEachDetailsRepository WhoIsThisProgramForEachDetails { get; }
        ILearningModelRepository LearningModelRepository { get; }
        ICoursePageRepository CoursePageRepository { get; }
        IContactBannerRepository ContactBannerRepository { get; }
        IContactDetailsRepository ContactDetailsRepository { get; }
        IContactFormRepository ContactFormRepository { get; }
        IEmployeesNumbersRepository EmployeesNumbersRepository { get; }
        ISubscriptionSystemRepository SubscriptionSystemRepository { get; }
        IContactPageRepository ContactpageRepository { get; }
        IBusinessBannerRepository BusinessBannerRepository { get; }
        IUpskillingImportanceRepository UpskillingImportanceRepository { get; }
        IUpskillingExplorationRepository UpskillingExplorationRepository { get; }
        ITrustedbyForUpSkillingRepository TrustedbyForUpSkillingRepository { get; }
        IWhyYouNeedUpskillingYourTeamRepository WhyYouNeedUpskillingYourTeamRepository { get; }
        IWhyYouNeedUpSkillingYourTeamSectionRepository WhyYouNeedUpSkillingYourTeamSection { get; }
        IBuillBetterSkillsFasterRepository BuillBetterSkillsFasterRepository { get; }
        IBuildBetterSkillsFasterSectionRepository BuildBetterSkillsFasterSectionRepository { get; }
        IGeolocationStudentsRepository GeolocationStudentsRepository { get; }
        IUpSkillingEmployeesRepository UpSkillingEmployeesRepository { get; }
        IITSkillsGapImpactsOnBusinessRepository ITSkillsGapImpactsOnBusiness { get; }
        IITGapSkillsSectionRepository ITGapSkillsSectionRepository { get; }
        IBusinessPageRepository BusinessPageRepository { get; }
        IMetaTagRepository MetaTagRepository { get; }

        void Commit();
    }
}
