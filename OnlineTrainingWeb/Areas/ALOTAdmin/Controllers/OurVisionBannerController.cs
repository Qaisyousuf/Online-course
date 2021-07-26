using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class OurVisionBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public OurVisionBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOurVisionBannerData()
        {
            var ourVisionbanner = uow.OurVisionBannerRepository.GetAll();

            List<OurVisionBannerViewModel> viewmodel = new List<OurVisionBannerViewModel>();

            foreach (var item in ourVisionbanner)
            {
                viewmodel.Add(new OurVisionBannerViewModel
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
            return View(new OurVisionBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(OurVisionBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ourVisionbanner = new OurVisionBanner
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

                uow.OurVisionBannerRepository.Add(ourVisionbanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ourVision = uow.OurVisionBannerRepository.GetById(id);

            OurVisionBannerViewModel viewmodel = new OurVisionBannerViewModel
            {
                Id=ourVision.Id,
                MainTitle=ourVision.MainTitle,
                SubTitle=ourVision.SubTitle,
                ImageUrl=ourVision.ImageUrl,
                JoinButton=ourVision.JoinButton,
                JoinButtonUrl=ourVision.JoinButtonUrl,
                DiscoverButton=ourVision.DiscoverButton,
                DiscoverButtonUrl=ourVision.DiscoverButton,
                
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OurVisionBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ourVision = uow.OurVisionBannerRepository.GetById(viewmodel.Id);

                ourVision.Id = viewmodel.Id;
                ourVision.MainTitle = viewmodel.MainTitle;
                ourVision.SubTitle = viewmodel.SubTitle;
                ourVision.ImageUrl = viewmodel.ImageUrl;
                ourVision.JoinButton = viewmodel.JoinButton;
                ourVision.JoinButtonUrl = viewmodel.JoinButtonUrl;
                ourVision.DiscoverButton = viewmodel.DiscoverButton;
                ourVision.DiscoverButtonTUrl = viewmodel.DiscoverButton;

                uow.OurVisionBannerRepository.Update(ourVision);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ourVision = uow.OurVisionBannerRepository.GetById(id);

            OurVisionBannerViewModel viewmodel = new OurVisionBannerViewModel
            {
                Id = ourVision.Id,
                MainTitle = ourVision.MainTitle,
                SubTitle = ourVision.SubTitle,
                ImageUrl = ourVision.ImageUrl,
                JoinButton = ourVision.JoinButton,
                JoinButtonUrl = ourVision.JoinButtonUrl,
                DiscoverButton = ourVision.DiscoverButton,
                DiscoverButtonUrl = ourVision.DiscoverButton,

            };

            uow.OurVisionBannerRepository.Remove(ourVision);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ourVision = uow.OurVisionBannerRepository.GetById(id);

            OurVisionBannerViewModel viewmodel = new OurVisionBannerViewModel
            {
                Id = ourVision.Id,
                MainTitle = ourVision.MainTitle,
                SubTitle = ourVision.SubTitle,
                ImageUrl = ourVision.ImageUrl,
                JoinButton = ourVision.JoinButton,
                JoinButtonUrl = ourVision.JoinButtonUrl,
                DiscoverButton = ourVision.DiscoverButton,
                DiscoverButtonUrl = ourVision.DiscoverButton,

            };

            return View(viewmodel);
        }
    }
}