using Data.Interfaces;
using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class HomeExplanationBannerController : Controller
    {
        private readonly IUnitOfWork uow;
        public HomeExplanationBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/HomeExplanationBanner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetHomeExplanationBanner()
        {
            var homeBanner = uow.HomeExplanationBannerRepository.GetAll();

            List<HomeExplorationBannerViewModel> viewmodel = new List<HomeExplorationBannerViewModel>();

            foreach (var item in homeBanner)
            {
                viewmodel.Add(new HomeExplorationBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new HomeExplorationBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(HomeExplorationBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                HomeExplorationBanner homeExplorationbanner = new HomeExplorationBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                };

                uow.HomeExplanationBannerRepository.Add(homeExplorationbanner);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var homeBannerExploration = uow.HomeExplanationBannerRepository.GetById(id);

            HomeExplorationBannerViewModel viewmodel = new HomeExplorationBannerViewModel
            {
                Id=homeBannerExploration.Id,
                MainTitle=homeBannerExploration.MainTitle,
                SubTitle=homeBannerExploration.SubTitle,
            };

            return View(viewmodel);
        }
        
        [HttpPost]
        public ActionResult Edit(HomeExplorationBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var homeExplorationBanner = uow.HomeExplanationBannerRepository.GetById(viewmodel.Id);

                homeExplorationBanner.Id = viewmodel.Id;
                homeExplorationBanner.SubTitle = viewmodel.SubTitle;
                homeExplorationBanner.MainTitle = viewmodel.MainTitle;

                uow.HomeExplanationBannerRepository.Update(homeExplorationBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var homeExplorationBanner = uow.HomeExplanationBannerRepository.GetById(id);

            HomeExplorationBannerViewModel viewmodel = new HomeExplorationBannerViewModel
            {
                Id=homeExplorationBanner.Id,
                MainTitle=homeExplorationBanner.MainTitle,
                SubTitle=homeExplorationBanner.SubTitle,
            };

            uow.HomeExplanationBannerRepository.Remove(homeExplorationBanner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var homeExplorationBanner = uow.HomeExplanationBannerRepository.GetById(id);

            HomeExplorationBannerViewModel viewmodel = new HomeExplorationBannerViewModel
            {
                Id = homeExplorationBanner.Id,
                MainTitle = homeExplorationBanner.MainTitle,
                SubTitle = homeExplorationBanner.SubTitle,
            };

            return View(viewmodel);
        }
    }
}