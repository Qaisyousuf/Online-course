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
    public class SubscriptionContentController : Controller
    {
        private readonly IUnitOfWork uow;

        public SubscriptionContentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSubscriptionContentData()
        {
            var subscriptionContent = uow.SubscriptionContentRepository.GetAll();

            List<SubscriptionContentViewModel> viewmodel = new List<SubscriptionContentViewModel>();

            foreach (var item in subscriptionContent)
            {
                viewmodel.Add(new SubscriptionContentViewModel
                {
                    Id=item.Id,
                    MainContent=item.MainContent,
                    Title=item.Title,
                    SubContent=item.SubContent,
                    MainTitle=item.MainTitle,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SubscriptionContentViewModel());
        }

        [HttpPost]
        public ActionResult Create(SubscriptionContentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var subscriptionContent = new SubscriptionContent
                {
                    Id=viewmodel.Id,
                    MainContent=viewmodel.MainContent,
                    Title=viewmodel.Title,
                    SubContent=viewmodel.SubContent,
                    MainTitle=viewmodel.MainTitle,
                    AnimationUrl=viewmodel.AnimationUrl,
                };
                uow.SubscriptionContentRepository.Add(subscriptionContent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var subscriptionContent = uow.SubscriptionContentRepository.GetById(id);

            SubscriptionContentViewModel viewmodel = new SubscriptionContentViewModel
            {
                Id=subscriptionContent.Id,
                MainTitle=subscriptionContent.MainTitle,
                Title=subscriptionContent.Title,
                MainContent=subscriptionContent.MainContent,
                SubContent=subscriptionContent.SubContent,
                AnimationUrl=subscriptionContent.AnimationUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SubscriptionContentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var subscriptionContent = uow.SubscriptionContentRepository.GetById(viewmodel.Id);

                subscriptionContent.Id = viewmodel.Id;
                subscriptionContent.MainTitle = viewmodel.MainTitle;
                subscriptionContent.Title = viewmodel.Title;
                subscriptionContent.MainContent = viewmodel.MainContent;
                subscriptionContent.SubContent = viewmodel.SubContent;
                subscriptionContent.AnimationUrl = viewmodel.AnimationUrl;

                uow.SubscriptionContentRepository.Update(subscriptionContent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var subscriptionContent = uow.SubscriptionContentRepository.GetById(id);

            SubscriptionContentViewModel viewmodel = new SubscriptionContentViewModel
            {
                Id=subscriptionContent.Id,
                MainTitle=subscriptionContent.MainTitle,
                Title=subscriptionContent.Title,
                MainContent=subscriptionContent.MainContent,
                SubContent=subscriptionContent.SubContent,
                AnimationUrl=subscriptionContent.AnimationUrl,
            };

            uow.SubscriptionContentRepository.Remove(subscriptionContent);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var subscriptionContent = uow.SubscriptionContentRepository.GetById(id);

            SubscriptionContentViewModel viewmodel = new SubscriptionContentViewModel
            {
                Id = subscriptionContent.Id,
                MainTitle = subscriptionContent.MainTitle,
                Title = subscriptionContent.Title,
                MainContent = subscriptionContent.MainContent,
                SubContent = subscriptionContent.SubContent,
                AnimationUrl = subscriptionContent.AnimationUrl,
            };

            return View(viewmodel);
        }
    }
}