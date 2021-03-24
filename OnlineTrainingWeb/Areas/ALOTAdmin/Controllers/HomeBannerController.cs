using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTrainingWeb.ViewModel;
using Data.Interfaces;
using ViewModel;
using Model;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class HomeBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetHomeBanner()
        {
            var _HomeBanner = uow.HomeBannerRepository.GetAll();

            List<HomeBannerViewModel> viewmodel = new List<HomeBannerViewModel>();

            foreach (var item in _HomeBanner)
            {
                viewmodel.Add(new HomeBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonUrl=item.DiscoverButton,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
          return View(new HomeBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(HomeBannerViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                HomeBanner homebanner = new HomeBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonTUrl=viewmodel.DiscoverButton,
                };

                uow.HomeBannerRepository.Add(homebanner);
                uow.Commit();

               
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _HomeBanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=_HomeBanner.Id,
                MainTitle=_HomeBanner.MainTitle,
                SubTitle=_HomeBanner.SubTitle,
                ImageUrl=_HomeBanner.ImageUrl,
                JoinButton=_HomeBanner.JoinButton,
                JoinButtonUrl=_HomeBanner.JoinButtonUrl,
                DiscoverButton=_HomeBanner.DiscoverButton,
                DiscoverButtonUrl=_HomeBanner.DiscoverButton,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(HomeBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var homeBanner = uow.HomeBannerRepository.GetById(viewmodel.Id);

                homeBanner.Id = viewmodel.Id;
                homeBanner.MainTitle = viewmodel.MainTitle;
                homeBanner.SubTitle = viewmodel.SubTitle;
                homeBanner.ImageUrl = viewmodel.ImageUrl;
                homeBanner.JoinButton = viewmodel.JoinButton;
                homeBanner.JoinButtonUrl = viewmodel.JoinButtonUrl;
                homeBanner.DiscoverButton = viewmodel.DiscoverButton;
                homeBanner.DiscoverButtonTUrl = viewmodel.DiscoverButton;

                uow.HomeBannerRepository.Update(homeBanner);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var homeBanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homeBanner.Id,
                MainTitle=homeBanner.MainTitle,
                SubTitle=homeBanner.SubTitle,
                ImageUrl=homeBanner.ImageUrl,
                JoinButton=homeBanner.JoinButton,
                DiscoverButton=homeBanner.DiscoverButton,
                JoinButtonUrl=homeBanner.JoinButtonUrl,
                DiscoverButtonUrl=homeBanner.JoinButtonUrl,

            };

            uow.HomeBannerRepository.Remove(homeBanner);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var homeBanner = uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id = homeBanner.Id,
                MainTitle = homeBanner.MainTitle,
                SubTitle = homeBanner.SubTitle,
                ImageUrl = homeBanner.ImageUrl,
                JoinButton = homeBanner.JoinButton,
                DiscoverButton = homeBanner.DiscoverButton,
                JoinButtonUrl = homeBanner.JoinButtonUrl,
                DiscoverButtonUrl = homeBanner.JoinButtonUrl,
            };

            return View(viewmodel);
        }
    }
}