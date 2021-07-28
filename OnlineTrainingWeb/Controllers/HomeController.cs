using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "home";
            if(!_uow.HomePageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page not found";
                return RedirectToAction(nameof(Index), new { slug="" });
            }

            HomePageViewModel viewmodel;
            HomePage pagefromDb;
            pagefromDb = _uow.HomePageRepository.GetHomePageBySlug(slug);
            ViewBag.PageTitle = pagefromDb.Title;

            TempData["HomeBanner"] = pagefromDb.HomeBannerId;
            TempData["ExplorationBanner"] = pagefromDb.HomeExplorationBannerId;

            viewmodel = new HomePageViewModel
            {
                Id=pagefromDb.Id,
                Title=pagefromDb.Title,
                Content=pagefromDb.Content,


            };
          
            return View(viewmodel);
        }

         [HttpGet]
         [ChildActionOnly]
         public ActionResult GetHomeBanner()
        {
            int id = (int)TempData["HomeBanner"];
            var homebanner = _uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homebanner.Id,
                MainTitle=homebanner.MainTitle,
                SubTitle=homebanner.SubTitle,
                ImageUrl=homebanner.ImageUrl,
                JoinButton=homebanner.JoinButton,
                JoinButtonUrl=homebanner.JoinButtonUrl,
                DiscoverButton=homebanner.DiscoverButton,
                DiscoverButtonUrl=homebanner.DiscoverButton,
                Content=homebanner.Content,
                SubMaintitle=homebanner.SubMaintitle,
                
            };

            return PartialView(viewmodel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetHomeExploration()
        {
            int id = (int)TempData["ExplorationBanner"];
            var homeExploraitonBanner = _uow.HomeExplanationBannerRepository.GetById(id);
            HomeExplorationBannerViewModel viewmodel = new HomeExplorationBannerViewModel
            {
                Id=homeExploraitonBanner.Id,
               MainTitle=homeExploraitonBanner.MainTitle,
               SubTitle=homeExploraitonBanner.SubTitle,

            };

            return PartialView(viewmodel);

        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCourseContent()
        {
            var courseContent = _uow.CourseContenntRepository.GetAll();

            List<CourseContentsViewModel> viewmodel = new List<CourseContentsViewModel>();

            foreach (var item in courseContent)
            {
                viewmodel.Add(new CourseContentsViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                  AnimationUrl =item.AnimationUrl,
                });
            }

            ListOfViewModels listOfCourseContentExploration = new ListOfViewModels
            {
                ListofCourseContentExploratoin=viewmodel
            };
            return PartialView(listOfCourseContentExploration);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetForlearner()
        {
            var forLearner = _uow.ForLearnerRepository.GetAll();

            List<ForLearnerViewModel> viewmodel = new List<ForLearnerViewModel>();

            foreach (var item in forLearner)
            {
                viewmodel.Add(new ForLearnerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            ListOfViewModels ForLearnerData = new ListOfViewModels
            {
                ListOfForLearner = viewmodel
            };

            return PartialView(ForLearnerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult CourseEachSection()
        {
            var courseEachSection = _uow.CourseSubSectionRepository.GetAll();

            List<CourseEachSectionViewModel> viewmodel = new List<CourseEachSectionViewModel>();

            foreach (var item in courseEachSection)
            {
                viewmodel.Add(new CourseEachSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    Duration=item.Duration,
                    ReadMoreButton=item.ReadMoreButton,
                    ReadMoreButtonUrl=item.ReadMoreButtonUrl,
                    DownloadCurriculumButton=item.DownloadCurriculumButton,
                    DwonloadCurriculumText=item.DwonloadCurriculumText,
                });
            }

            ListOfViewModels EachSectoinViewModel = new ListOfViewModels
            {
                ListCourseEachSection = viewmodel,
            };

            return PartialView(EachSectoinViewModel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOurVision()
        {
            var ourVision = _uow.OurVisionRepository.GetAll();

            List<OurVisionViewModel> viewmodel = new List<OurVisionViewModel>();

            foreach (var item in ourVision)
            {
                viewmodel.Add(new OurVisionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfViewModels OurVisionData = new ListOfViewModels
            {
                ListOfOurVision=viewmodel
            };

            return PartialView(OurVisionData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCovidData()
        {
            var covid = _uow.Covid19Repository.GetAll();

            List<COVID_19ViewModel> viewmodel = new List<COVID_19ViewModel>();

            foreach (var item in covid)
            {
                viewmodel.Add(new COVID_19ViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    CovidButtonText=item.CovidButtonText,
                    CovidButtonUrl=item.CovidButtonUrl,
                    CourseButtonText=item.CourseButtonText,
                    CourseButtonUrl=item.CourseButtonUrl,
                });
            }

            ListOfViewModels CovidData = new ListOfViewModels
            {
                ListOfCovid=viewmodel
            };

            return PartialView(CovidData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetMetaData()
        {
            var metaTag = _uow.MetaTagRepository.GetAll();

            List<MetaTagViewModel> viewmodel = new List<MetaTagViewModel>();

            foreach (var item in metaTag)
            {
                viewmodel.Add(new MetaTagViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Content=item.Content,
                });
            }

            ListOfViewModels MetaTagData = new ListOfViewModels
            {
                ListofMetaTag=viewmodel
            };

            return PartialView(MetaTagData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult TwitterTagData()
        {
            var twitterTag = _uow.TwitterTagRepository.GetAll();

            List<TwitterMetaTagsViewModel> viewmodel = new List<TwitterMetaTagsViewModel>();

            foreach (var item in twitterTag)
            {
                viewmodel.Add(new TwitterMetaTagsViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Content=item.Content,
                });
            }
            ListOfViewModels TwitterData = new ListOfViewModels
            {
                ListofTwitterTag=viewmodel
            };

            return PartialView(TwitterData);
        }
        [HttpGet]
        public ActionResult GetOGTagData()
        {
            var ogTag = _uow.OGTagsRepository.GetAll();

            List<OpenGraphMetaTagsViewModel> viewmodel = new List<OpenGraphMetaTagsViewModel>();

            foreach (var item in ogTag)
            {
                viewmodel.Add(new OpenGraphMetaTagsViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    
                    Content=item.Content,
                });
            }

            ListOfViewModels ogData = new ListOfViewModels
            {
                ListofOGTag=viewmodel
            };

            return PartialView(ogData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetQuizContent()
        {
            var quizDataFromdb = _uow.QuizContentRepository.GetAll();

            List<QuizContentViewModel> viewmodel = new List<QuizContentViewModel>();

            foreach (var item in quizDataFromdb)
            {
                viewmodel.Add(new QuizContentViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            ListOfViewModels QuizData = new ListOfViewModels
            {
                ListofQuizContnet=viewmodel
            };
            return PartialView(QuizData);
        }

      
        [ChildActionOnly]
        public ActionResult PartialMenus()
        {
           
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var menu in menus)
            {
                context.Entry(menu).Collection(s => s.SubMenus).Query().Where(x => x.ParentId == menu.Id);
            }
            var subMenus = menus.AsNoTracking().ToList();

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            //foreach (var item in viewmodel)
            //{
            //    viewmodel.Add(new MenusViewModel
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Description = item.Description,
            //        Url = item.Url,
            //        Parent = item.Parent,
            //        ParentId = item.ParentId,
            //    });
            //}

            context.Dispose();
            return PartialView(subMenus);
        }

        [HttpGet]
        [Route("OurVision")]
        public ActionResult OurVisionBanner()
        {
            var ourVision = _uow.OurVisionBannerRepository.GetAll();

            List<OurVisionBannerViewModel> OurVisonBannerVM = new List<OurVisionBannerViewModel>();

            foreach (var item in ourVision)
            {
                OurVisonBannerVM.Add(new OurVisionBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonUrl=item.DiscoverButtonTUrl,
                });
            }
            var visionExploration = _uow.OurVisionExplortaionRepository.GetAll();

            List<OurVisionExplationViewModel> viewmodel = new List<OurVisionExplationViewModel>();

            foreach (var item in visionExploration)
            {
                viewmodel.Add(new OurVisionExplationViewModel
                {
                    Id = item.Id,
                    MainTitle = item.MainTitle,
                    SubTitle = item.SubTitle,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                });
            }


            ListOfViewModels OurVisionBannerData = new ListOfViewModels
            {
                ListOfOurVisoinBanner= OurVisonBannerVM,
                ListofVisionExploration = viewmodel,
            };

            return View(OurVisionBannerData);
        }



    }
}