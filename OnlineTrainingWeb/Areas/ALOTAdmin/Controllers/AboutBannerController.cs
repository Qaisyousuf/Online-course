using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class AboutBannerController : Controller
    {
        private readonly IUnitOfWork uow;
        public AboutBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAboutBannerData()
        {
            var aboutBanner = uow.AboutBannerRepository.GetAll();

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

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new AboutBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(AboutBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var aboutBanner = new AboutBanner
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonUrl=viewmodel.DiscoverButtonUrl,
                    MainSubTitle=viewmodel.MainSubTitle,
                    Content=viewmodel.Content,
                };

                uow.AboutBannerRepository.Add(aboutBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutBanner = uow.AboutBannerRepository.GetById(id);

            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id=aboutBanner.Id,
                MainTitle=aboutBanner.MainTitle,
                SubTitle=aboutBanner.SubTitle,
                ImageUrl=aboutBanner.ImageUrl,
                JoinButton=aboutBanner.JoinButton,
                JoinButtonUrl=aboutBanner.JoinButtonUrl,
                DiscoverButton=aboutBanner.DiscoverButton,
                DiscoverButtonUrl=aboutBanner.DiscoverButtonUrl,
                MainSubTitle=aboutBanner.MainSubTitle,
                Content=aboutBanner.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AboutBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var aboutBanner = uow.AboutBannerRepository.GetById(viewmodel.Id);

                aboutBanner.Id = viewmodel.Id;
                aboutBanner.MainTitle = viewmodel.MainTitle;
                aboutBanner.SubTitle = viewmodel.SubTitle;
                aboutBanner.ImageUrl = viewmodel.ImageUrl;
                aboutBanner.DiscoverButton = viewmodel.DiscoverButton;
                aboutBanner.DiscoverButtonUrl = viewmodel.DiscoverButtonUrl;
                aboutBanner.JoinButton = viewmodel.JoinButton;
                aboutBanner.JoinButtonUrl = viewmodel.JoinButtonUrl;
                aboutBanner.MainSubTitle = viewmodel.MainSubTitle;
                aboutBanner.Content = viewmodel.Content;

                uow.AboutBannerRepository.Update(aboutBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var aboutBanner = uow.AboutBannerRepository.GetById(id);

            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id=aboutBanner.Id,
                MainTitle=aboutBanner.MainTitle,
                SubTitle=aboutBanner.SubTitle,
                ImageUrl=aboutBanner.ImageUrl,
                JoinButton=aboutBanner.JoinButton,
                JoinButtonUrl=aboutBanner.JoinButtonUrl,
                DiscoverButton=aboutBanner.DiscoverButton,
                DiscoverButtonUrl=aboutBanner.DiscoverButtonUrl,
                MainSubTitle=aboutBanner.MainSubTitle,
                Content=aboutBanner.Content,
            };

            uow.AboutBannerRepository.Remove(aboutBanner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var aboutBanner = uow.AboutBannerRepository.GetById(id);

            AboutBannerViewModel viewmodel = new AboutBannerViewModel
            {
                Id = aboutBanner.Id,
                MainTitle = aboutBanner.MainTitle,
                SubTitle = aboutBanner.SubTitle,
                ImageUrl = aboutBanner.ImageUrl,
                JoinButton = aboutBanner.JoinButton,
                JoinButtonUrl = aboutBanner.JoinButtonUrl,
                DiscoverButton = aboutBanner.DiscoverButton,
                DiscoverButtonUrl = aboutBanner.DiscoverButtonUrl,
                MainSubTitle=aboutBanner.MainSubTitle,
                Content=aboutBanner.Content,
            };

            return View(viewmodel);
        }
    }
}