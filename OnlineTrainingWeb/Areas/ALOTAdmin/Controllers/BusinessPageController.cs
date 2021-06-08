using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;
using Services;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class BusinessPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public BusinessPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            GetBusinessRelatedData();
            return View();
        }

        private void GetBusinessRelatedData()
        {
            ViewBag.BusinessBanner = uow.BusinessBannerRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetBusinessPageData()
        {
            var businessPage = uow.BusinessPageRepository.GetAll("BusinessBanner");

            List<BusinessPageViewModel> viewmodel = new List<BusinessPageViewModel>();

            foreach (var item in businessPage)
            {
                viewmodel.Add(new BusinessPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    BusinessBanner=item.BusinessBanner,
                    BusinessBannerId=item.BusinessBannerId,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetBusinessRelatedData();
            return View(new BusinessPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(BusinessPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetBusinessRelatedData();
                return View(viewmodel);
            }

            string slug;

            BusinessPage businessPage = new BusinessPage();

            businessPage.Id = viewmodel.Id;
            businessPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.BusinessPageRepository.SlugExists(viewmodel.Id,slug))
            {
                GetBusinessRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            businessPage.Slug = slug;

            businessPage.Content = viewmodel.Content;
            businessPage.BusinessBanner = viewmodel.BusinessBanner;
            businessPage.BusinessBannerId = viewmodel.BusinessBannerId;

            uow.BusinessPageRepository.Add(businessPage);
            uow.Commit();
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var businessPage = uow.BusinessPageRepository.GetById(id);

            BusinessPageViewModel viewmodel = new BusinessPageViewModel
            {
                Id=businessPage.Id,
                Title=businessPage.Title,
                Content=businessPage.Content,
                BusinessBanner=businessPage.BusinessBanner,
                BusinessBannerId=businessPage.BusinessBannerId,
            };

            GetBusinessRelatedData();
            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit(BusinessPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetBusinessRelatedData();
                return View(viewmodel);
            }

            string slug;
            var businessPage = uow.BusinessPageRepository.GetById(viewmodel.Id);

            businessPage.Id = viewmodel.Id;
            businessPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.BusinessPageRepository.SlugExists(slug))
            {
                GetBusinessRelatedData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            businessPage.Slug = slug;
            businessPage.Content = viewmodel.Content;
            businessPage.BusinessBanner = viewmodel.BusinessBanner;
            businessPage.BusinessBannerId = viewmodel.BusinessBannerId;

            uow.BusinessPageRepository.Update(businessPage);
            uow.Commit();
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var businessPage = uow.BusinessPageRepository.GetById(id);

            BusinessPageViewModel viewmodel = new BusinessPageViewModel
            {
                Id = businessPage.Id,
                Title = businessPage.Title,
                Content = businessPage.Content,
                BusinessBanner = businessPage.BusinessBanner,
                BusinessBannerId = businessPage.BusinessBannerId,
            };

            uow.BusinessPageRepository.Remove(businessPage);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var businessPage = uow.BusinessPageRepository.GetById(id);

            BusinessPageViewModel viewmodel = new BusinessPageViewModel
            {
                Id = businessPage.Id,
                Title = businessPage.Title,
                Content = businessPage.Content,
                BusinessBanner = businessPage.BusinessBanner,
                BusinessBannerId = businessPage.BusinessBannerId,
            };

            GetBusinessRelatedData();
            return View(viewmodel);

        }
    }
}