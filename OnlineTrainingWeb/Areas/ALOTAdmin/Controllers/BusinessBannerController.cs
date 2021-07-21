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
    public class BusinessBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public BusinessBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBusinessBannerData()
        {
            var businessBanner = uow.BusinessBannerRepository.GetAll();

            List<BusinessBannerViewModel> viewmodel = new List<BusinessBannerViewModel>();

            foreach (var item in businessBanner)
            {
                viewmodel.Add(new BusinessBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    ImageUrl=item.ImageUrl,
                    JoinButton=item.JoinButton,
                    JoinButtonUrl=item.JoinButtonUrl,
                    DiscoverButton=item.DiscoverButton,
                    DiscoverButtonTUrl=item.DiscoverButtonTUrl,
                    Content=item.Content,
                    SubContent=item.SubContent,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BusinessBannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(BusinessBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var businessBanner = new BusinessBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonTUrl=viewmodel.DiscoverButtonTUrl,
                    Content=viewmodel.Content,
                    SubContent=viewmodel.SubContent,

                };

                uow.BusinessBannerRepository.Add(businessBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var businessBanner = uow.BusinessBannerRepository.GetById(id);

            BusinessBannerViewModel viewmodel = new BusinessBannerViewModel
            {
                Id=businessBanner.Id,
                MainTitle=businessBanner.MainTitle,
                SubTitle=businessBanner.SubTitle,
                ImageUrl=businessBanner.ImageUrl,
                JoinButton=businessBanner.JoinButton,
                JoinButtonUrl=businessBanner.JoinButtonUrl,
                DiscoverButton=businessBanner.DiscoverButton,
                DiscoverButtonTUrl=businessBanner.DiscoverButtonTUrl,
                Content=businessBanner.Content,
                SubContent=businessBanner.SubContent,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(BusinessBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var businessCard = uow.BusinessBannerRepository.GetById(viewmodel.Id);

                businessCard.Id = viewmodel.Id;
                businessCard.MainTitle = viewmodel.MainTitle;
                businessCard.SubTitle = viewmodel.SubTitle;
                businessCard.ImageUrl = viewmodel.ImageUrl;
                businessCard.JoinButton = viewmodel.JoinButton;
                businessCard.JoinButtonUrl = viewmodel.JoinButtonUrl;
                businessCard.DiscoverButton = viewmodel.DiscoverButton;
                businessCard.DiscoverButtonTUrl = viewmodel.DiscoverButtonTUrl;
                businessCard.Content = viewmodel.Content;
                businessCard.SubContent = viewmodel.SubContent;

                uow.BusinessBannerRepository.Update(businessCard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var businessBanner = uow.BusinessBannerRepository.GetById(id);

            BusinessBannerViewModel viewmodel = new BusinessBannerViewModel
            {
                Id = businessBanner.Id,
                MainTitle = businessBanner.MainTitle,
                SubTitle = businessBanner.SubTitle,
                ImageUrl = businessBanner.ImageUrl,
                JoinButton = businessBanner.JoinButton,
                JoinButtonUrl = businessBanner.JoinButtonUrl,
                DiscoverButton = businessBanner.DiscoverButton,
                DiscoverButtonTUrl = businessBanner.DiscoverButtonTUrl,
                Content=businessBanner.Content,
                SubContent=businessBanner.SubContent,
            };
            uow.BusinessBannerRepository.Remove(businessBanner);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var businessBanner = uow.BusinessBannerRepository.GetById(id);

            BusinessBannerViewModel viewmodel = new BusinessBannerViewModel
            {
                Id = businessBanner.Id,
                MainTitle = businessBanner.MainTitle,
                SubTitle = businessBanner.SubTitle,
                ImageUrl = businessBanner.ImageUrl,
                JoinButton = businessBanner.JoinButton,
                JoinButtonUrl = businessBanner.JoinButtonUrl,
                DiscoverButton = businessBanner.DiscoverButton,
                DiscoverButtonTUrl = businessBanner.DiscoverButtonTUrl,
                Content=businessBanner.Content,
                SubContent=businessBanner.SubContent,
            };

            return View(viewmodel);
        }

    }
    
}