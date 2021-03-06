namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModelsAddedToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        BannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AboutBanners", t => t.BannerId, cascadeDelete: true)
                .Index(t => t.BannerId);
            
            CreateTable(
                "dbo.BuildBetterSkillsFasterSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        IconUrl = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BuillBetterSkillsFasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        AnimatinUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactCounters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        CounterNumber = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        WorkingStartDate = c.DateTime(nullable: false),
                        WrokingEndDate = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        JobTitle = c.String(),
                        Message = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryNames", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Emplyees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.CountryNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emplyees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfEmployee = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        ContactBannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactBanners", t => t.ContactBannerId, cascadeDelete: true)
                .Index(t => t.ContactBannerId);
            
            CreateTable(
                "dbo.CourseBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContentExplanations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        TakeCourseButton = c.String(),
                        TakeCourseButtonUrl = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Duration = c.String(),
                        Language = c.String(),
                        ProgramName = c.String(),
                        VideoLanguage = c.String(),
                        Trainer = c.String(),
                        ImageUrl = c.String(),
                        Certification = c.String(),
                        Level = c.String(),
                        Availability = c.String(),
                        SutdentFinished = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseEachSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        Duration = c.String(),
                        ReadMoreButton = c.String(),
                        ReadMoreButtonUrl = c.String(),
                        DownloadCurriculumButton = c.String(),
                        DwonloadCurriculumText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoursePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        CourseBannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseBanners", t => t.CourseBannerId, cascadeDelete: true)
                .Index(t => t.CourseBannerId);
            
            CreateTable(
                "dbo.COVID_19",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForLearners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeolocationStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Name = c.String(),
                        Country = c.String(),
                        ProgramName = c.String(),
                        CountryFlag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeCourseSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        Content = c.String(),
                        NumberofView = c.String(),
                        RedMoreButton = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeExplorationBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Slug = c.String(),
                        HomeBannerId = c.Int(nullable: false),
                        HomeExplorationBannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeBanners", t => t.HomeBannerId, cascadeDelete: true)
                .ForeignKey("dbo.HomeExplorationBanners", t => t.HomeExplorationBannerId, cascadeDelete: true)
                .Index(t => t.HomeBannerId)
                .Index(t => t.HomeExplorationBannerId);
            
            CreateTable(
                "dbo.HowOnlineTrainingWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        VideoUrl = c.String(),
                        AnimationUrl = c.String(),
                        LogoUrlIOS = c.String(),
                        LogoUrlandroid = c.String(),
                        ApplicationDownloadButton = c.String(),
                        ApplicationDownloadUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LaunchYourCodingCareers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        VideoUrl = c.String(),
                        AnimationUrl = c.String(),
                        RegisterButton = c.String(),
                        RegisterButtonUrl = c.String(),
                        TakeCourseButton = c.String(),
                        TakeCourseButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LearningModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MetaTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Onlinetrainingbenefits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpenGraphMetaTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OurVisionExplations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OurVisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quiklinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        IconUrl = c.String(),
                        LinkUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizBasicInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryNames", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.QuizContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        QuizDateTiem = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionsName = c.String(),
                        QuestoinContent = c.String(),
                        QuizPage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizPages", t => t.QuizPage_Id)
                .Index(t => t.QuizPage_Id);
            
            CreateTable(
                "dbo.StudentsSays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        ProgramName = c.String(),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        SubContent = c.String(),
                        MainContent = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThankYouPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        ContactedInfo = c.String(),
                        AnimatioUrl = c.String(),
                        ResponseEamil = c.String(),
                        HomeButtonUrl = c.String(),
                        HomeButtonText = c.String(),
                        CourseButtonUrl = c.String(),
                        CourseButtonText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainerIntroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AboutTrainer = c.String(),
                        TrainerImageUrl = c.String(),
                        TrainerAnimation = c.String(),
                        TrainerLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainerPhilosophies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Name = c.String(),
                        Content = c.String(),
                        ProfileImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainerSocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialMediaProfileUrl = c.String(),
                        SocialMediaIconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainerVisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ProfileImageUrl = c.String(),
                        TrainerName = c.String(),
                        BestRegards = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrustedbyForUpSkillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        AnimationUrl = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TwitterMetaTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpskillingExplorations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        AnimationUrl = c.String(),
                        Content = c.String(),
                        IconUlr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpskillingImportances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Animation = c.String(),
                        RegisterButton = c.String(),
                        RegisterButtonUrl = c.String(),
                        ContactButton = c.String(),
                        ContactButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserbenefitsContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Maintitle = c.String(),
                        Content = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBenefitsSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        Name = c.String(),
                        CountryFlagUrl = c.String(),
                        CountryName = c.String(),
                        VideoUrl = c.String(),
                        ProgramCompletionDate = c.DateTime(nullable: false),
                        ProgramImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OurVisionBanners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        ImageUrl = c.String(),
                        JoinButton = c.String(),
                        JoinButtonUrl = c.String(),
                        DiscoverButton = c.String(),
                        DiscoverButtonTUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhatTrainerLoves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhatYouWillLearns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhoIsThisProgramForContentSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        VideoUrl = c.String(),
                        ReadMoreButton = c.String(),
                        ReadMoreButtonUrl = c.String(),
                        AnimationContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhoIsThisProgramForEachDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhyOnlineTrainingIsImportants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.Int(nullable: false),
                        MainContent = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        IconUrl = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhyYouNeedUpskillingYourTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Content = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WhyYouNeedUpSkillingYourTeamSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTitle = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        AnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkExperienceTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagsName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YouMayLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Contetn = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkExperienceTagsWorkExperiences",
                c => new
                    {
                        WorkExperienceTags_Id = c.Int(nullable: false),
                        WorkExperience_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkExperienceTags_Id, t.WorkExperience_Id })
                .ForeignKey("dbo.WorkExperienceTags", t => t.WorkExperienceTags_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkExperiences", t => t.WorkExperience_Id, cascadeDelete: true)
                .Index(t => t.WorkExperienceTags_Id)
                .Index(t => t.WorkExperience_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperienceTagsWorkExperiences", "WorkExperience_Id", "dbo.WorkExperiences");
            DropForeignKey("dbo.WorkExperienceTagsWorkExperiences", "WorkExperienceTags_Id", "dbo.WorkExperienceTags");
            DropForeignKey("dbo.QuizQuestions", "QuizPage_Id", "dbo.QuizPages");
            DropForeignKey("dbo.QuizBasicInfoes", "CountryId", "dbo.CountryNames");
            DropForeignKey("dbo.HomePages", "HomeExplorationBannerId", "dbo.HomeExplorationBanners");
            DropForeignKey("dbo.HomePages", "HomeBannerId", "dbo.HomeBanners");
            DropForeignKey("dbo.CoursePages", "CourseBannerId", "dbo.CourseBanners");
            DropForeignKey("dbo.ContactPages", "ContactBannerId", "dbo.ContactBanners");
            DropForeignKey("dbo.ContactForms", "EmployeeId", "dbo.Emplyees");
            DropForeignKey("dbo.ContactForms", "CountryId", "dbo.CountryNames");
            DropForeignKey("dbo.AboutPages", "BannerId", "dbo.AboutBanners");
            DropIndex("dbo.WorkExperienceTagsWorkExperiences", new[] { "WorkExperience_Id" });
            DropIndex("dbo.WorkExperienceTagsWorkExperiences", new[] { "WorkExperienceTags_Id" });
            DropIndex("dbo.QuizQuestions", new[] { "QuizPage_Id" });
            DropIndex("dbo.QuizBasicInfoes", new[] { "CountryId" });
            DropIndex("dbo.HomePages", new[] { "HomeExplorationBannerId" });
            DropIndex("dbo.HomePages", new[] { "HomeBannerId" });
            DropIndex("dbo.CoursePages", new[] { "CourseBannerId" });
            DropIndex("dbo.ContactPages", new[] { "ContactBannerId" });
            DropIndex("dbo.ContactForms", new[] { "CountryId" });
            DropIndex("dbo.ContactForms", new[] { "EmployeeId" });
            DropIndex("dbo.AboutPages", new[] { "BannerId" });
            DropTable("dbo.WorkExperienceTagsWorkExperiences");
            DropTable("dbo.YouMayLikes");
            DropTable("dbo.WorkExperienceTags");
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.WhyYouNeedUpSkillingYourTeamSections");
            DropTable("dbo.WhyYouNeedUpskillingYourTeams");
            DropTable("dbo.WhyOnlineTrainingIsImportants");
            DropTable("dbo.WhoIsThisProgramForEachDetails");
            DropTable("dbo.WhoIsThisProgramForContentSections");
            DropTable("dbo.WhatYouWillLearns");
            DropTable("dbo.WhatTrainerLoves");
            DropTable("dbo.OurVisionBanners");
            DropTable("dbo.VideoReviews");
            DropTable("dbo.UserBenefitsSections");
            DropTable("dbo.UserbenefitsContents");
            DropTable("dbo.UpskillingImportances");
            DropTable("dbo.UpskillingExplorations");
            DropTable("dbo.TwitterMetaTags");
            DropTable("dbo.TrustedbyForUpSkillings");
            DropTable("dbo.TrainerVisions");
            DropTable("dbo.TrainerSocialMedias");
            DropTable("dbo.TrainerPhilosophies");
            DropTable("dbo.TrainerIntroes");
            DropTable("dbo.ThankYouPages");
            DropTable("dbo.SubscriptionSystems");
            DropTable("dbo.SubscriptionContents");
            DropTable("dbo.StudentsSays");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.QuizPages");
            DropTable("dbo.QuizContents");
            DropTable("dbo.QuizBasicInfoes");
            DropTable("dbo.Quiklinks");
            DropTable("dbo.OurVisions");
            DropTable("dbo.OurVisionExplations");
            DropTable("dbo.OpenGraphMetaTags");
            DropTable("dbo.Onlinetrainingbenefits");
            DropTable("dbo.MetaTags");
            DropTable("dbo.LearningModels");
            DropTable("dbo.LaunchYourCodingCareers");
            DropTable("dbo.HowOnlineTrainingWorks");
            DropTable("dbo.HomePages");
            DropTable("dbo.HomeExplorationBanners");
            DropTable("dbo.HomeCourseSections");
            DropTable("dbo.HomeBanners");
            DropTable("dbo.GeolocationStudents");
            DropTable("dbo.ForLearners");
            DropTable("dbo.COVID_19");
            DropTable("dbo.CoursePages");
            DropTable("dbo.CourseEachSections");
            DropTable("dbo.CourseDetails");
            DropTable("dbo.CourseDescriptions");
            DropTable("dbo.CourseContents");
            DropTable("dbo.CourseContentExplanations");
            DropTable("dbo.CourseBanners");
            DropTable("dbo.ContactPages");
            DropTable("dbo.Emplyees");
            DropTable("dbo.CountryNames");
            DropTable("dbo.ContactForms");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.ContactCounters");
            DropTable("dbo.ContactBanners");
            DropTable("dbo.BusinessBanners");
            DropTable("dbo.BuillBetterSkillsFasters");
            DropTable("dbo.BuildBetterSkillsFasterSections");
            DropTable("dbo.AboutPages");
        }
    }
}
