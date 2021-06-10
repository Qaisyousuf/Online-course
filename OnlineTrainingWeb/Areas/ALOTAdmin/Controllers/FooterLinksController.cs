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
    public class FooterLinksController : Controller
    {
        private readonly IUnitOfWork uow;

        public FooterLinksController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFooterLinksData()
        {
            var footerLinks = uow.FooterLinksRepository.GetAll();

            List<FooterLinksViewModel> viewmodel = new List<FooterLinksViewModel>();

            foreach (var item in footerLinks)
            {
                viewmodel.Add(new FooterLinksViewModel
                {
                    Id=item.Id,
                    LinkUrl=item.LinkUrl,
                    NavigationName=item.NavigationName,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var SiteSettings = uow.SiteSettingrepository.GetAll();
            return View(new FooterLinksViewModel());
        }

        [HttpPost]
        public ActionResult Create(FooterLinksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var footerlinks = new FooterLinks
                {
                    Id=viewmodel.Id,
                    LinkUrl=viewmodel.LinkUrl,
                    NavigationName=viewmodel.NavigationName,
                    SiteSettings=viewmodel.SiteSettings,
                };

                uow.FooterLinksRepository.Add(footerlinks);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var footerlinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id=footerlinks.Id,
                NavigationName=footerlinks.NavigationName,
                LinkUrl=footerlinks.LinkUrl,
                SiteSettings=footerlinks.SiteSettings,
            };
            var SiteSettings = uow.SiteSettingrepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(FooterLinksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var footerlinks = uow.FooterLinksRepository.GetById(viewmodel.Id);

                footerlinks.Id = viewmodel.Id;
                footerlinks.NavigationName = viewmodel.NavigationName;
                footerlinks.LinkUrl = viewmodel.LinkUrl;

                uow.FooterLinksRepository.Update(footerlinks);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var footerlinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id = footerlinks.Id,
                NavigationName = footerlinks.NavigationName,
                LinkUrl = footerlinks.LinkUrl,
            };
            uow.FooterLinksRepository.Remove(footerlinks);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var footerlinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id = footerlinks.Id,
                NavigationName = footerlinks.NavigationName,
                LinkUrl = footerlinks.LinkUrl,
            };

            return View(viewmodel);
        }
    }
}