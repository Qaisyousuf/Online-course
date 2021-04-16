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

        void Commit();
    }
}
