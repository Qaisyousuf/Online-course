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
    }
}