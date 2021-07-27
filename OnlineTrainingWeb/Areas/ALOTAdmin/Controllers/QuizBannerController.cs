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
    public class QuizBannerController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizBannerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuizBannerData()
        {
            var quizBanner = uow.QuizBannerRepository.GetAll();

            List<QuizBannerViewModel> viewmodel = new List<QuizBannerViewModel>();

            foreach (var item in quizBanner)
            {
                viewmodel.Add(new QuizBannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
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
            return View(new QuizBannerViewModel());
        }
        [HttpPost]
        public ActionResult Create(QuizBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizBanner = new QuizBanner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                    JoinButton=viewmodel.JoinButton,
                    JoinButtonUrl=viewmodel.JoinButtonUrl,
                    DiscoverButton=viewmodel.DiscoverButton,
                    DiscoverButtonTUrl=viewmodel.DiscoverButtonTUrl,
                };

                uow.QuizBannerRepository.Add(quizBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizBanner = uow.QuizBannerRepository.GetById(id);

            QuizBannerViewModel viewmodel = new QuizBannerViewModel
            {
                Id=quizBanner.Id,
                MainTitle=quizBanner.MainTitle,
                Content=quizBanner.Content,
                ImageUrl=quizBanner.ImageUrl,
                JoinButton=quizBanner.JoinButton,
                JoinButtonUrl=quizBanner.JoinButtonUrl,
                DiscoverButton=quizBanner.DiscoverButton,
                DiscoverButtonTUrl=quizBanner.DiscoverButtonTUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizBannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizBanner = uow.QuizBannerRepository.GetById(viewmodel.Id);

                quizBanner.Id = viewmodel.Id;
                quizBanner.MainTitle = viewmodel.MainTitle;
                quizBanner.Content = viewmodel.Content;
                quizBanner.ImageUrl = viewmodel.ImageUrl;
                quizBanner.JoinButton = viewmodel.JoinButton;
                quizBanner.JoinButtonUrl = viewmodel.JoinButtonUrl;
                quizBanner.DiscoverButton = viewmodel.DiscoverButton;
                quizBanner.DiscoverButtonTUrl = viewmodel.DiscoverButtonTUrl;

                uow.QuizBannerRepository.Update(quizBanner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizBanner = uow.QuizBannerRepository.GetById(id);

            QuizBannerViewModel viewmodel = new QuizBannerViewModel
            {
                Id = quizBanner.Id,
                MainTitle = quizBanner.MainTitle,
                Content = quizBanner.Content,
                ImageUrl = quizBanner.ImageUrl,
                JoinButton = quizBanner.JoinButton,
                JoinButtonUrl = quizBanner.JoinButtonUrl,
                DiscoverButton = quizBanner.DiscoverButton,
                DiscoverButtonTUrl = quizBanner.DiscoverButtonTUrl,
            };

            uow.QuizBannerRepository.Remove(quizBanner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizBanner = uow.QuizBannerRepository.GetById(id);

            QuizBannerViewModel viewmodel = new QuizBannerViewModel
            {
                Id = quizBanner.Id,
                MainTitle = quizBanner.MainTitle,
                Content = quizBanner.Content,
                ImageUrl = quizBanner.ImageUrl,
                JoinButton = quizBanner.JoinButton,
                JoinButtonUrl = quizBanner.JoinButtonUrl,
                DiscoverButton = quizBanner.DiscoverButton,
                DiscoverButtonTUrl = quizBanner.DiscoverButtonTUrl,
            };
            return View(viewmodel);
        }
    }
}