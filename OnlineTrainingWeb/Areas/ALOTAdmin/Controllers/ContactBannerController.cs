using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class ContactBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public ContactBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContactBannerData()
        {
            var contactBanner = uow.ContactBannerRepository.GetAll();

            List<ContactBannerViewModel> viewmodel = new List<ContactBannerViewModel>();

            foreach (var item in contactBanner)
            {
                viewmodel.Add(new ContactBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                });

              
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactBannerViewModel());

        }

        [HttpPost]
        public ActionResult Create(ContactBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactBanner = new ContactBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonTUrl=viewmodel.DiscoverButtonTUrl,
                };

                uow.ContactBannerRepository.Add(contactBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contactBanner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id=contactBanner.Id,
                MainTitle=contactBanner.MainTitle,
                SubTitle=contactBanner.SubTitle,
                ImageUrl=contactBanner.ImageUrl,
                JoinButton=contactBanner.JoinButton,
                JoinButtonUrl=contactBanner.JoinButtonUrl,
                DiscoverButton=contactBanner.DiscoverButton,
                DiscoverButtonTUrl=contactBanner.DiscoverButtonTUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ContactBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var contactBanner = uow.ContactBannerRepository.GetById(viewmodel.Id);

                contactBanner.Id = viewmodel.Id;
                contactBanner.MainTitle = viewmodel.MainTitle;
                contactBanner.SubTitle = viewmodel.SubTitle;
                contactBanner.ImageUrl = viewmodel.ImageUrl;
                contactBanner.JoinButton = viewmodel.JoinButton;
                contactBanner.JoinButtonUrl = viewmodel.JoinButtonUrl;
                contactBanner.DiscoverButton = viewmodel.DiscoverButton;
                contactBanner.DiscoverButtonTUrl = viewmodel.DiscoverButtonTUrl;

                uow.ContactBannerRepository.Update(contactBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contactBanner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id = contactBanner.Id,
                MainTitle = contactBanner.MainTitle,
                SubTitle = contactBanner.SubTitle,
                ImageUrl = contactBanner.ImageUrl,
                JoinButton = contactBanner.JoinButton,
                JoinButtonUrl = contactBanner.JoinButtonUrl,
                DiscoverButton = contactBanner.DiscoverButton,
                DiscoverButtonTUrl = contactBanner.DiscoverButtonTUrl,
            };

            uow.ContactBannerRepository.Remove(contactBanner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var contactBanner = uow.ContactBannerRepository.GetById(id);

            ContactBannerViewModel viewmodel = new ContactBannerViewModel
            {
                Id = contactBanner.Id,
                MainTitle = contactBanner.MainTitle,
                SubTitle = contactBanner.SubTitle,
                ImageUrl = contactBanner.ImageUrl,
                JoinButton = contactBanner.JoinButton,
                JoinButtonUrl = contactBanner.JoinButtonUrl,
                DiscoverButton = contactBanner.DiscoverButton,
                DiscoverButtonTUrl = contactBanner.DiscoverButtonTUrl,
            };

            return View(viewmodel);
        }
    }
}