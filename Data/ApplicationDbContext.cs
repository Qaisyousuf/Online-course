using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using System.Data.Entity;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ALOnlineTraining", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AboutBanner> AboutBanners { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<BuildBetterSkillsFasterSection> BetterSkillsFasterSections { get; set; }
        public DbSet<BuillBetterSkillsFaster> BuillBetterSkillsFasters { get; set; }
        public DbSet<BusinessBanner> BusinessBanners { get; set; }
        public DbSet<ContactBanner> ContactBanners { get; set; }
        public DbSet<ContactCounter> ContactCounters { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<CountryName> CountryNames { get; set; }
        public DbSet<CourseBanner> CourseBanners { get; set; }
        public DbSet<CourseContentExplanation> CourseContentExplanations { get; set; }
        public DbSet<CourseContents> CourseContents { get; set; }
        public DbSet<CourseDescription> CourseDescriptions { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<CourseEachSection> CourseEachSections { get; set; }
        public DbSet<CoursePage> CoursePages { get; set; }
        public DbSet<COVID_19> COVID_19s { get; set; }
        public DbSet<Emplyees> Emplyees { get; set; }
        public DbSet<ForLearner> ForLearners { get; set; }
        public DbSet<GeolocationStudents> GeolocationStudents { get; set; }
        public DbSet<HomeBanner> HomeBanners { get; set; }
        public DbSet<HomeCourseSection> HomeCourseSections { get; set; }
        public DbSet<HomeExplorationBanner> HomeExplorationBanners { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<HowOnlineTrainingWorks> HowOnlineTrainingWorks { get; set; }
        public DbSet<LaunchYourCodingCareer> LaunchYourCodingCareers { get; set; }
        public DbSet<LearningModel> LearningModels { get; set; }
        public DbSet<MetaTag> MetaTags { get; set; }
        public DbSet<Onlinetrainingbenefits> Onlinetrainingbenefits { get; set; }
        public DbSet<OpenGraphMetaTags> OpenGraphMetaTags { get; set; }
        public DbSet<OurVision> OurVisions { get; set; }
        public DbSet<OurVisionBanner> VisionBanners { get; set; }
        public DbSet<OurVisionExplation> OurVisionExplations { get; set; }
        public DbSet<Quiklink> Quiklinks { get; set; }
        public DbSet<QuizBasicInfo> QuizBasicInfos { get; set; }
        public DbSet<QuizContent> QuizContents { get; set; }
        public DbSet<QuizPage> QuizPages { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; } 
        public DbSet<StudentsSay> StudentsSays { get; set; }
        public DbSet<SubscriptionContent> SubscriptionContents { get; set; }
        public DbSet<SubscriptionSystem> SubscriptionSystems { get; set; }
        public DbSet<ThankYouPage> ThankYouPages { get; set; } 
        public DbSet<TrainerIntro> TrainerIntros { get; set; }
        public DbSet<TrainerPhilosophy> TrainerPhilosophies { get; set; }
        public DbSet<TrainerSocialMedia> TrainerSocialMedias { get; set; }
        public DbSet<TrainerVision> TrainerVisions { get; set; }
        public DbSet<TrustedbyForUpSkilling> TrustedbyForUpSkillings { get; set; }
        public DbSet<TwitterMetaTags> TwitterMetaTags { get; set; }
        public DbSet<UpskillingExploration> UpskillingExplorations { get; set; }
        public DbSet<UpskillingImportance> UpskillingImportances { get; set; }
        public DbSet<UserbenefitsContents> UserbenefitsContents { get; set; }
        public DbSet<UserBenefitsSection> UserBenefitsSections { get; set; }
        public DbSet<VideoReview> VideoReviews { get; set; }
        public DbSet<WhatTrainerLoves> WhatTrainerLoves { get; set; }
        public DbSet<WhatYouWillLearn> WhatYouWillLearns { get; set; }
        public DbSet<WhoIsThisProgramForContentSection> WhoIsThisProgramForContentSections { get; set; }
        public DbSet<WhoIsThisProgramForEachDetails> WhoIsThisProgramForEachDetails { get; set; }
        public DbSet<WhyOnlineTrainingIsImportant> WhyOnlineTrainingIsImportants { get; set; }
        public DbSet<WhyYouNeedUpskillingYourTeam> WhyYouNeedUpskillingYourTeams { get; set; }
        public DbSet<WhyYouNeedUpSkillingYourTeamSection> WhyYouNeedUpSkillingYourTeamSections { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<WorkExperienceTags> WorkExperienceTags { get; set; }
        public DbSet<YouMayLike> YouMayLikes { get; set; }
        public DbSet<QuizResults> QuizResults { get; set; }
        public DbSet<UpskillingEmployee> UpskillingEmployees { get; set; }
        public DbSet<ITSkillsGapImpactsOnBusiness> ITSkillsGapImpactsOnBusinesses { get; set; }
        public DbSet<ITSkillGapSection> ITSkillsGapSections { get; set; }
        public DbSet<BusinessPage> BusinessPages { get; set; }




        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
