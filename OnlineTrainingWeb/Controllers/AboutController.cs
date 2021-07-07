using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Controllers
{
    public class AboutController : BaseController
    {
       
        [Route("about-us")]
        public ActionResult Index(string slug)
        {
            var aboutPage = _uow.AboutPageRepository.GetAll();

            List<AboutPageViewModel> viewmodel = new List<AboutPageViewModel>();

            foreach (var item in aboutPage)
            {
                viewmodel.Add(new AboutPageViewModel
                {
                    Id=item.Id,
                    Slug=item.Slug,
                    Content=item.Content,
                    Title=item.Title,
                    BannerId=item.BannerId,
                    AboutBanners=item.AboutBanners,
                    
                });

                ViewBag.PagetTitle = item.Title;

             
            }
           
           

            ListOfViewModels aboutPageData = new ListOfViewModels
            {
                ListofAboutPage=viewmodel
            };

            return View(aboutPageData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAboutBanner()
        {
            var aboutBanner = _uow.AboutBannerRepository.GetAll();

            List<AboutBannerViewModel> viewmodel = new List<AboutBannerViewModel>();

            foreach (var item in aboutBanner)
            {
                viewmodel.Add(new AboutBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonUrl=item.DiscoverButtonUrl,
                    MainSubTitle=item.MainSubTitle,
                    Content=item.Content,
                });
            }
            ListOfViewModels AboutBannerData = new ListOfViewModels
            {
                ListofAboutBanner=viewmodel
            };

            return PartialView(AboutBannerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOnlineTrainingBenefits()
        {
            var onlineTrainingBenefits = _uow.OnlinetrainingbenefitsRepository.GetAll();

            List<OnlinetrainingbenefitsViewModel> viewmodel = new List<OnlinetrainingbenefitsViewModel>();
            foreach (var item in onlineTrainingBenefits)
            {
                viewmodel.Add(new OnlinetrainingbenefitsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            ListOfViewModels OnlinTraningBenefitsData = new ListOfViewModels
            {
                ListofOnlinTrainingBenefits=viewmodel
            };

            return PartialView(OnlinTraningBenefitsData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserBenefitsContent()
        {
            var userBenefits = _uow.UserbenefitsContentsRepository.GetAll();

            List<UserbenefitsContentsViewModel> viewmodel = new List<UserbenefitsContentsViewModel>();

            foreach (var item in userBenefits)
            {
                viewmodel.Add(new UserbenefitsContentsViewModel
                {
                    Id=item.Id,
                    Maintitle=item.Maintitle,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    Content=item.Content,
                });
            }
            ListOfViewModels UserBenefitsContentData = new ListOfViewModels
            {
                ListOfUserBenefitsContent=viewmodel
            };

            return PartialView(UserBenefitsContentData);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserBenefitsSection()
        {
            var userBenefitsSection = _uow.UserBenefitsSectionRepository.GetAll();

            List<UserBenefitsSectionViewModel> viewmodel = new List<UserBenefitsSectionViewModel>();

            foreach (var item in userBenefitsSection)
            {
                viewmodel.Add(new UserBenefitsSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    IconUrl=item.IconUrl,
                });
            }

            ListOfViewModels UserBenefitsSectionData = new ListOfViewModels
            {
                ListofUserBenefitsSection = viewmodel,
            };

            return PartialView(UserBenefitsSectionData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult HowOnlineTraningWorks()
        {
            var howOnlineTrainingWorks = _uow.HowOnlineTrainingWorksRepository.GetAll();

            List<HowOnlineTrainingWorksViewModel> viewmodel = new List<HowOnlineTrainingWorksViewModel>();
            foreach (var item in howOnlineTrainingWorks)
            {
                viewmodel.Add(new HowOnlineTrainingWorksViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    VideoUrl=item.VideoUrl,
                    AnimationUrl=item.AnimationUrl,
                    LogoUrlandroid=item.LogoUrlandroid,
                    LogoUrlIOS=item.LogoUrlIOS,
                    ApplicationDownloadButton=item.ApplicationDownloadButton,
                    ApplicationDownloadUrl=item.ApplicationDownloadUrl,
                });
            }

            ListOfViewModels HowOnlineTrainingWorks = new ListOfViewModels
            {
                ListofHowOnlineTrainingWorks=viewmodel,
            };
            return PartialView(HowOnlineTrainingWorks);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult ImportanceOfOnlineTraining()
        {
            var importanceofOnlineTraining = _uow.WhyOnlineTrainingIsImportantRepository.GetAll();

            List<WhyOnlineTrainingIsImportantViewModel> viewmodel = new List<WhyOnlineTrainingIsImportantViewModel>();

            foreach (var item in importanceofOnlineTraining)
            {
                viewmodel.Add(new WhyOnlineTrainingIsImportantViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    MainContent=item.MainContent,
                    Title=item.Title,
                    SubContent=item.SubContent,
                    IconUrl=item.IconUrl,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            ListOfViewModels ImportanceOfOnlineTrainingData = new ListOfViewModels
            {
                ListofImporanceofOnlineTraining=viewmodel,
            };
            return PartialView(ImportanceOfOnlineTrainingData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult StudentSays()
        {
            var studentSays = _uow.StudentsSaysRepository.GetAll();

            List<StudentsSayViewModel> viewmodel = new List<StudentsSayViewModel>();

            foreach (var item in studentSays)
            {
                viewmodel.Add(new StudentsSayViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ProgramName=item.ProgramName,
                    StudentName=item.StudentName,
                    CountryName=item.CountryName,
                    PicUrl=item.PicUrl,
                });
            }

            ListOfViewModels StudentSays = new ListOfViewModels
            {
                ListofStudentSays=viewmodel,
            };

            return PartialView(StudentSays);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetVedioReview()
        {
            var videoReview = _uow.VideoReviewRepository.GetAll();

            List<VideoReviewViewModel> viewmodel = new List<VideoReviewViewModel>();

            foreach (var item in videoReview)
            {
                viewmodel.Add(new VideoReviewViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    Name=item.Name,
                    CountryFlagUrl=item.CountryFlagUrl,
                    VideoUrl=item.VideoUrl,
                    ProgramCompletionDate=item.ProgramCompletionDate,
                    ProgramImageUrl=item.ProgramImageUrl,
                });
            }

            ListOfViewModels VideoReviewData = new ListOfViewModels
            {
                ListofVideoReview=viewmodel,
            };

            return PartialView(VideoReviewData);
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetTrainerIntro()
        {
            var trainerIntro = _uow.TrainerIntroRepository.GetAll();

            List<TrainerIntroViewModel> viewmodel = new List<TrainerIntroViewModel>();

            foreach (var item in trainerIntro)
            {
                viewmodel.Add(new TrainerIntroViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    AboutTrainer=item.AboutTrainer,
                    TrainerAnimation=item.TrainerAnimation,
                    TrainerImageUrl=item.TrainerImageUrl,
                    TrainerLocation=item.TrainerLocation,
                });
            }

            var trainerSocialMedia = _uow.TrainerSocialMediaRepository.GetAll();

            List<TrainerSocialMediaViewModel> SocialMediaViewModel = new List<TrainerSocialMediaViewModel>();

            foreach (var item in trainerSocialMedia)
            {
                SocialMediaViewModel.Add(new TrainerSocialMediaViewModel
                {
                    Id = item.Id,
                    SocialMediaProfileUrl = item.SocialMediaProfileUrl,
                    SocialMediaIconUrl = item.SocialMediaIconUrl,
                });
            }

            ListOfViewModels TrainerIntroData = new ListOfViewModels
            {
                ListofTrainerIntro=viewmodel,
                ListOfTrainerSocialMedia=SocialMediaViewModel
            };
            return PartialView(TrainerIntroData);
        }
       [HttpGet]
       [ChildActionOnly]
       public ActionResult TrainerWorkExperience()
        {
            var trainerWorkExperinece = _uow.WorkExperienceRepository.GetAll("WorkExperTags").ToList();

            List<WorkExperienceViewModel> viewmodel = new List<WorkExperienceViewModel>();

            foreach (var item in trainerWorkExperinece)
            {
                var WorkTagsId = item.WorkExperTags.Select(x => x.Id).ToList();

                var tagName = _uow.Context.WorkExperienceTags.Where(x=>WorkTagsId.Contains(x.Id)).Select(x => x.TagsName).ToList();
                viewmodel.Add(new WorkExperienceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    AnimationUrlFooter=item.AnimationUrl,
                    TagsNames=tagName,

                });
            }


            var workTags = _uow.WorkExperienceTagsRepository.GetAll();

            List<WorkExperienceTagsViewModel> WorkTagViewModel = new List<WorkExperienceTagsViewModel>();

            foreach (var item in workTags)
            {
                WorkTagViewModel.Add(new WorkExperienceTagsViewModel
                {
                    Id=item.Id,
                    TagsName=item.TagsName,
                });
            }
            ListOfViewModels WorkExperienceData = new ListOfViewModels
            {
                ListOfWorkExperince=viewmodel,
                ListOfWorkTags=WorkTagViewModel,
            };
            return PartialView(WorkExperienceData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult TrainePhilosophy()
        {
            var trainerPhilosophy = _uow.TrainerPhilosophyRepository.GetAll();

            List<TrainerPhilosophyViewModel> viewmodel = new List<TrainerPhilosophyViewModel>();

            foreach (var item in trainerPhilosophy)
            {
                viewmodel.Add(new TrainerPhilosophyViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Name=item.Name,
                    Content=item.Content,
                    ProfileImageUrl=item.ProfileImageUrl,
                });
            }

            var trainerLoves = _uow.WhatTrainerLovesRepository.GetAll();

            List<WhatTrainerLovesViewModel> trainerIntrest = new List<WhatTrainerLovesViewModel>();

            foreach (var item in trainerLoves)
            {
                trainerIntrest.Add(new WhatTrainerLovesViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    IconUrl=item.IconUrl,
                });
            }

            var trainerVision = _uow.TrainerVisionRepository.GetAll();

            List<TrainerVisionViewModel> trainerVisionViewModel = new List<TrainerVisionViewModel>();

            foreach (var item in trainerVision)
            {
                trainerVisionViewModel.Add(new TrainerVisionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ProfileImageUrl=item.ProfileImageUrl,
                    TrainerName=item.TrainerName,
                    BestRegards=item.BestRegards,
                });
            }

            ListOfViewModels TrainerPhilosophyData = new ListOfViewModels
            {
                ListofTrainerPhilosophy=viewmodel,
                ListofWhatTrainerLoves=trainerIntrest,
                ListofTraienrVision=trainerVisionViewModel,
            };

            return PartialView(TrainerPhilosophyData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetSubscriptionContent()
        {
            var subscriptionContent = _uow.SubscriptionContentRepository.GetAll();

            List<SubscriptionContentViewModel> viewmodel = new List<SubscriptionContentViewModel>();

            foreach (var item in subscriptionContent)
            {
                viewmodel.Add(new SubscriptionContentViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainContent=item.MainContent,
                    SubContent=item.SubContent,
                    MainTitle=item.MainTitle,
                    AnimationUrl=item.AnimationUrl,
                });
            }
            
            ListOfViewModels SubscriptionContetnData = new ListOfViewModels
            {
                ListofSubscriptionContent=viewmodel,
            };

            return PartialView(SubscriptionContetnData);
        }

        [Route("about-us")]
        [HttpGet]
        public ActionResult GetNewsLetter(string slug)
        {
            return View(new SubscriptionSystemViewModel());
        }
        [Route("about-us")]
        [HttpPost]
        public ActionResult GetNewsLetter(SubscriptionSystemViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var EmailExists = _uow.Context.SubscriptionSystems.Any(x => x.Email == viewmodel.Email);

                if(EmailExists)
                {
                    return Json(new { error = true, message = "Email already exists" }, JsonRequestBehavior.AllowGet);
                }

                var subscription = new SubscriptionSystem
                {
                    UserName=viewmodel.UserName,
                    Email=viewmodel.Email,
                };

                _uow.SubscriptionSystemRepository.Add(subscription);
                _uow.Commit();

                
            }

            return Json(new { success = true, message = "Thanks for subscribing" }, JsonRequestBehavior.AllowGet);

        }

        [Route("ThankYou")]
        public ActionResult ThankYou()
        {
            return View(new SubscriptionSystemViewModel());
        }
    }
}