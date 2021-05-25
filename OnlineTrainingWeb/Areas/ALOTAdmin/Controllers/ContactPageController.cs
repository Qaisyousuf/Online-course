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
    public class ContactPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void ContactPageData()
        {
            ViewBag.ContactBanner = uow.ContactBannerRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetContactPageData()
        {
            var contactPage = uow.ContactpageRepository.GetAll("ContactBanners");

            List<ContactPageViewModel> viewmodel = new List<ContactPageViewModel>();

            foreach (var item in contactPage)
            {
                viewmodel.Add(new ContactPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    ContactBannerId=item.ContactBannerId,
                    ContactBanners=item.ContactBanners,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ContactPageData();
            return View(new ContactPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ContactPageData();
                return View(viewmodel);
            }

            string slug;

            ContactPage contactPage = new ContactPage();

            contactPage.Id = viewmodel.Id;
            contactPage.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.ContactpageRepository.SlugExists(viewmodel.Id,slug))
            {
                ContactPageData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            contactPage.Slug = slug;
            contactPage.ContactBannerId = viewmodel.ContactBannerId;
            contactPage.ContactBanners = viewmodel.ContactBanners;
            contactPage.Content = viewmodel.Content;

            uow.ContactpageRepository.Add(contactPage);
            uow.Commit();

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactPage = uow.ContactpageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id=contactPage.Id,
                Title=contactPage.Title,
                Slug=contactPage.Slug,
                Content=contactPage.Content,
                ContactBannerId=contactPage.ContactBannerId,
                ContactBanners=contactPage.ContactBanners,
            };

            ContactPageData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactPageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                ContactPageData();
                return View(viewmodel);
            }

            string slug;

            var contactPage = uow.ContactpageRepository.GetById(viewmodel.Id);

            contactPage.Id = viewmodel.Id;
            contactPage.Title = viewmodel.Title;


            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.ContactpageRepository.SlugExists(slug))
            {
                ContactPageData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            contactPage.Slug = slug;
            contactPage.ContactBannerId = viewmodel.ContactBannerId;
            contactPage.ContactBanners = viewmodel.ContactBanners;
            contactPage.Content = viewmodel.Content;

            uow.ContactpageRepository.Update(contactPage);
            uow.Commit();
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactPage = uow.ContactpageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {
                Id=contactPage.Id,
                Title=contactPage.Title,
                Slug=contactPage.Slug,
                Content=contactPage.Content,
                ContactBannerId=contactPage.ContactBannerId,
                ContactBanners=contactPage.ContactBanners,
            };

            uow.ContactpageRepository.Remove(contactPage);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contapge = uow.ContactpageRepository.GetById(id);

            ContactPageViewModel viewmodel = new ContactPageViewModel
            {

                Id=contapge.Id,
                Title=contapge.Title,
                Slug=contapge.Slug,
                ContactBannerId=contapge.ContactBannerId,
                ContactBanners=contapge.ContactBanners,
                Content=contapge.Content,
            };

            ContactPageData();
            return View(viewmodel);


        }


    }
}