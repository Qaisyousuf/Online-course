using Data.Interfaces;
using Models;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;
using Services;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomePageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void HomePageRelatedData()
        {
            ViewBag.HomeBannerData = uow.HomeBannerRepository.GetAll();
            ViewBag.HomeExplorationData = uow.HomeExplanationBannerRepository.GetAll();
        }

        public ActionResult GetHomePageData()
        {
            var homePage = uow.HomePageRepository.GetAll("HomeBanner", "HomeExplorationBanner");

            List<HomePageViewModel> viewmodel = new List<HomePageViewModel>();

            foreach (var item in homePage)
            {
                viewmodel.Add(new HomePageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    Slug=item.Slug,
                    HomeBanner=item.HomeBanner,
                    HomeBannerId=item.HomeBannerId,
                    HomeExplorationBanner=item.HomeExplorationBanner,
                    HomeExplorationBannerId=item.HomeExplorationBannerId,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            HomePageRelatedData();

            return View(new HomePageViewModel());
        }

        [HttpPost]
        public ActionResult Create(HomePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                HomePageRelatedData();
                return View(viewmodel);
            }

            string slug;

            HomePage homepage = new HomePage();

            homepage.Id = viewmodel.Id;
            homepage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.HomePageRepository.SlugExists(slug))
            {
                HomePageRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);

                
            }
            homepage.Slug = slug;
            homepage.Content = viewmodel.Content;
            homepage.HomeBannerId = viewmodel.HomeBannerId;
            homepage.HomeBanner = viewmodel.HomeBanner;
            homepage.HomeExplorationBanner = viewmodel.HomeExplorationBanner;
            homepage.HomeExplorationBannerId = viewmodel.HomeExplorationBannerId;

            uow.HomePageRepository.Add(homepage);
            uow.Commit();

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homePage = uow.HomePageRepository.GetById(id);

            HomePageViewModel viewmodel = new HomePageViewModel
            {
                Id=homePage.Id,
                Title=homePage.Title,
                Slug=homePage.Slug,
                Content=homePage.Content,
                HomeBannerId=homePage.HomeBannerId,
                HomeBanner=homePage.HomeBanner,
                HomeExplorationBanner=homePage.HomeExplorationBanner,
                HomeExplorationBannerId=homePage.HomeExplorationBannerId,
            };
            HomePageRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HomePageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                HomePageRelatedData();

                return View(new HomePageViewModel());
            }

            var homepage = uow.HomePageRepository.GetById(viewmodel.Id);

            homepage.Id = viewmodel.Id;
            homepage.Title = viewmodel.Title;
            string slug;
            if (string.IsNullOrEmpty(viewmodel.Slug))
               slug=SlugHelper.Create(true, viewmodel.Title);
            else
               slug=SlugHelper.Create(true, viewmodel.Slug);

            if(uow.HomePageRepository.SlugExists(viewmodel.Id,slug))
            {
                HomePageRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            homepage.Slug = slug;
            homepage.Content = viewmodel.Content;
            homepage.HomeBanner = viewmodel.HomeBanner;
            homepage.HomeBannerId = viewmodel.HomeBannerId;
            homepage.HomeExplorationBanner = viewmodel.HomeExplorationBanner;
            homepage.HomeExplorationBannerId = viewmodel.HomeExplorationBannerId;

            uow.HomePageRepository.Update(homepage);
            uow.Commit();
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var homepage = uow.HomePageRepository.GetById(id);

            HomePageViewModel viewmodel = new HomePageViewModel
            {
                Id=homepage.Id,
                Title=homepage.Title,
                Slug=homepage.Slug,
                Content=homepage.Content,
                HomeBanner=homepage.HomeBanner,
                HomeBannerId=homepage.HomeBannerId,
                HomeExplorationBanner=homepage.HomeExplorationBanner,
                HomeExplorationBannerId=homepage.HomeExplorationBannerId,
            };

            uow.HomePageRepository.Remove(homepage);
            uow.Commit();

            HomePageRelatedData();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var homePage = uow.HomePageRepository.GetById(id);

            HomePageViewModel viewmodel = new HomePageViewModel
            {
                Id = homePage.Id,
                Title = homePage.Title,
                Slug = homePage.Slug,
                Content=homePage.Content,
                HomeBannerId = homePage.HomeBannerId,
                HomeBanner = homePage.HomeBanner,
                HomeExplorationBanner = homePage.HomeExplorationBanner,
                HomeExplorationBannerId = homePage.HomeExplorationBannerId,
            };
            HomePageRelatedData();
            return View(viewmodel);
        }

    }
}