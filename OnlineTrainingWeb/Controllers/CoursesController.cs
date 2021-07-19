using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class CoursesController : BaseController
    {
        [Route("Courses")]
        public ActionResult Index()
        {
            var courses = _uow.CoursePageRepository.GetAll();

            List<CoursePageViewModel> viewmodel = new List<CoursePageViewModel>();

            foreach (var item in courses)
            {
                viewmodel.Add(new CoursePageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    CourseBanner=item.CourseBanner,
                    CourseBannerId=item.CourseBannerId,
                    
                });
                ViewBag.Title = item.Title;
            }

            ListOfViewModels CoursesPageData = new ListOfViewModels
            {
                ListOfCoursePage=viewmodel,
            };
            return View(CoursesPageData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult CoursesBanner()
        {
            var coursesBanner = _uow.CourseBannerRepository.GetAll();

            List<CourseBannerViewModel> BannerViewModel = new List<CourseBannerViewModel>();

            foreach (var item in coursesBanner)
            {
                BannerViewModel.Add(new CourseBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    SubContent=item.SubContent,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                });
            }
            ListOfViewModels BannerData = new ListOfViewModels
            {
                ListofCourseBanner=BannerViewModel,
            };
            return PartialView(BannerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult CodingCareer()
        {
            var codingCareer = _uow.launchYourCoding.GetAll();

            List<LaunchYourCodingCareerViewModel> viewmodel = new List<LaunchYourCodingCareerViewModel>();

            foreach (var item in codingCareer)
            {
                viewmodel.Add(new LaunchYourCodingCareerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    VideoUrl=item.VideoUrl,
                    AnimationUrl=item.AnimationUrl,
                    RegisterButton=item.RegisterButton,
                    RegisterButtonUrl=item.RegisterButtonUrl,
                    TakeCourseButton=item.TakeCourseButton,
                    TakeCourseButtonUrl=item.TakeCourseButtonUrl,
                });
            }

            ListOfViewModels CodingCareerData = new ListOfViewModels
            {
                ListofCodingCareer=viewmodel,
            };

            return PartialView(CodingCareerData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult CoursesDescriptionsData()
        {
            var coursesDescription = _uow.CourseDescriptionRepository.GetAll();

            List<CourseDescriptionViewModel> viewmodel = new List<CourseDescriptionViewModel>();

            foreach (var item in coursesDescription)
            {
                viewmodel.Add(new CourseDescriptionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    TakeCourseButton=item.TakeCourseButton,
                    TakeCourseButtonUrl=item.TakeCourseButtonUrl,
                    ImageUrl=item.ImageUrl,
                });
            }

            ListOfViewModels GetCoursesDescription = new ListOfViewModels
            {
                ListofCoursesDescriptions=viewmodel,
            };

            return PartialView(GetCoursesDescription);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult LearningModel()
        {
            var learningModel = _uow.LearningModelRepository.GetAll();

            List<LearningModelViewModel> viewmodel = new List<LearningModelViewModel>();

            foreach (var item in learningModel)
            {
                viewmodel.Add(new LearningModelViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    IconUrl=item.IconUrl,

                });
            }

            ListOfViewModels GetLearningModel = new ListOfViewModels
            {
                ListOfLearningModel=viewmodel,
            };

            return PartialView(GetLearningModel);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult WhoIsThisProgramForData()
        {
            var whoisthiprogramfor = _uow.ThisProgramForWhoContentSectionRepository.GetAll();

            List<WhoIsThisProgramForContentSectionViewModel> viewmodel = new List<WhoIsThisProgramForContentSectionViewModel>();

            foreach (var item in whoisthiprogramfor)
            {
                viewmodel.Add(new WhoIsThisProgramForContentSectionViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    VideoUrl=item.VideoUrl,
                    ReadMoreButton=item.ReadMoreButton,
                    ReadMoreButtonUrl=item.ReadMoreButtonUrl,
                    AnimationContent=item.AnimationContent,
                });
            }

            var programDetails = _uow.WhoIsThisProgramForEachDetails.GetAll();

            List<WhoIsThisProgramForEachDetailsViewModel> DetailsViewModel = new List<WhoIsThisProgramForEachDetailsViewModel>();

            foreach (var item in programDetails)
            {
                DetailsViewModel.Add(new WhoIsThisProgramForEachDetailsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    IconUrl=item.IconUrl,
                });
            }

            ListOfViewModels GetWhoIsThisProgramFor = new ListOfViewModels
            {
                ListOfThisProgramFor=viewmodel,
                ListofProgramDetails=DetailsViewModel,
            };

            return PartialView(GetWhoIsThisProgramFor);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetQuikLinks()
        {
            var quiklink = _uow.QuiklinkRepository.GetAll();
            List<QuiklinkViewModel> quiklinkViewModel = new List<QuiklinkViewModel>();

            foreach (var item in quiklink)
            {
                quiklinkViewModel.Add(new QuiklinkViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    IconUrl=item.IconUrl,
                    LinkUrl=item.LinkUrl,

                });
            }

            ListOfViewModels GetQuikLinkData = new ListOfViewModels
            {
                ListofQuikLink=quiklinkViewModel,
            };

            return PartialView(GetQuikLinkData);

        }

    }
}