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
    }
}