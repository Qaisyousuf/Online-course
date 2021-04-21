using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;
using Services;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class AboutPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public AboutPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            GetAboutPageDataRelatedData();
            return View();
        }

        private void GetAboutPageDataRelatedData()
        {
            ViewBag.AboutBanner = uow.AboutBannerRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetAboutPageData()
        {
            var aboutPage = uow.AboutPageRepository.GetAll("AboutBanners");

            List<AboutPageViewModel> viewmodel = new List<AboutPageViewModel>();

            foreach (var item in aboutPage)
            {
                viewmodel.Add(new AboutPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    BannerId=item.BannerId,
                    AboutBanners=item.AboutBanners,
                    
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetAboutPageDataRelatedData();
            return View(new AboutPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(AboutPageViewModel viewmodoel)
        {
            if(!ModelState.IsValid)
            {
                GetAboutPageDataRelatedData();
                return View(viewmodoel);
            }

            string slug;

            AboutPage aboutPage = new AboutPage();

            aboutPage.Id = viewmodoel.Id;
            aboutPage.Title = viewmodoel.Title;

            if (string.IsNullOrEmpty(viewmodoel.Slug))
                slug = SlugHelper.Create(true, viewmodoel.Title);
            else
                slug = SlugHelper.Create(true, viewmodoel.Slug);

            if(uow.AboutPageRepository.SlugExists(viewmodoel.Id,slug))
            {
                GetAboutPageDataRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            aboutPage.Slug = slug;
            aboutPage.Content = viewmodoel.Content;
            aboutPage.BannerId = viewmodoel.BannerId;
            aboutPage.AboutBanners = viewmodoel.AboutBanners;

            uow.AboutPageRepository.Add(aboutPage);
            uow.Commit();

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id=aboutPage.Id,
                Title=aboutPage.Title,
                Slug=aboutPage.Slug,
                Content=aboutPage.Content,
                BannerId=aboutPage.BannerId,
                AboutBanners=aboutPage.AboutBanners,

            };

            GetAboutPageDataRelatedData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(AboutPageViewModel viewmoodel)
        {
            if(!ModelState.IsValid)
            {
                GetAboutPageDataRelatedData();
                return View(viewmoodel);
            }

            string slug;

            var aboutPage = uow.AboutPageRepository.GetById(viewmoodel.Id);

            aboutPage.Id = viewmoodel.Id;
            aboutPage.Title = viewmoodel.Title;

            if (string.IsNullOrEmpty(viewmoodel.Slug))
                slug = SlugHelper.Create(true, viewmoodel.Title);
            else
                slug = SlugHelper.Create(true, viewmoodel.Slug);

            if(uow.AboutPageRepository.SlugExists(slug))
            {
                GetAboutPageDataRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            aboutPage.Slug = slug;
            aboutPage.Content = viewmoodel.Content;
            aboutPage.BannerId = viewmoodel.BannerId;
            aboutPage.AboutBanners = viewmoodel.AboutBanners;

            uow.AboutPageRepository.Update(aboutPage);
            uow.Commit();

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodle = new AboutPageViewModel
            {
                Id=aboutPage.Id,
                Title=aboutPage.Title,
                Slug=aboutPage.Slug,
                Content=aboutPage.Content,
                BannerId=aboutPage.BannerId,
                AboutBanners=aboutPage.AboutBanners,
            };

            uow.AboutPageRepository.Remove(aboutPage);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var aboutPage = uow.AboutPageRepository.GetById(id);

            AboutPageViewModel viewmodel = new AboutPageViewModel
            {
                Id = aboutPage.Id,
                Title = aboutPage.Title,
                Slug = aboutPage.Slug,
                Content = aboutPage.Content,
                BannerId = aboutPage.BannerId,
                AboutBanners = aboutPage.AboutBanners,

            };

            GetAboutPageDataRelatedData();
            return View(viewmodel);
        }
    }
}