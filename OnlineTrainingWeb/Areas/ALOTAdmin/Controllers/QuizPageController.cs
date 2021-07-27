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
    public class QuizPageController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizPageController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuizPage()
        {
            var quizPage = uow.QuizPageRepository.GetAll("QuizBanners");

            List<QuizPageViewModel> viewmodel = new List<QuizPageViewModel>();

            foreach (var item in quizPage)
            {
                viewmodel.Add(new QuizPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    QuizBannerId=item.QuizBannerId,
                    QuizBanners=item.QuizBanners,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.QuizBanner = uow.QuizBannerRepository.GetAll();
            return View(new QuizPageViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuizPageViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizPage = new QuizPage
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Content=viewmodel.Content,
                    QuizBannerId=viewmodel.QuizBannerId,
                    QuizBanners=viewmodel.QuizBanners,
                };

                uow.QuizPageRepository.Add(quizPage);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizPage = uow.QuizPageRepository.GetById(id);

            QuizPageViewModel viewmodel = new QuizPageViewModel
            {
                Id=quizPage.Id,
                Title=quizPage.Title,
                QuizBannerId=quizPage.QuizBannerId,
                QuizBanners=quizPage.QuizBanners,
                Content=quizPage.Content,
            };
            ViewBag.QuizBanner = uow.QuizBannerRepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizPageViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizPage = uow.QuizPageRepository.GetById(viewmodel.Id);

                quizPage.Id = viewmodel.Id;
                quizPage.Title = viewmodel.Title;
                quizPage.Content = viewmodel.Content;
                quizPage.QuizBannerId = viewmodel.QuizBannerId;
                quizPage.QuizBanners = viewmodel.QuizBanners;

                uow.QuizPageRepository.Update(quizPage);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizPage = uow.QuizPageRepository.GetById(id);

            QuizPageViewModel viewmodel = new QuizPageViewModel
            {
                Id = quizPage.Id,
                Title = quizPage.Title,
                QuizBannerId = quizPage.QuizBannerId,
                QuizBanners = quizPage.QuizBanners,
                Content = quizPage.Content,
            };

            uow.QuizPageRepository.Remove(quizPage);
            uow.Commit();
            ViewBag.QuizBanner = uow.QuizBannerRepository.GetAll();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizPage = uow.QuizPageRepository.GetById(id);

            QuizPageViewModel viewmodel = new QuizPageViewModel
            {
                Id = quizPage.Id,
                Title = quizPage.Title,
                QuizBannerId = quizPage.QuizBannerId,
                QuizBanners = quizPage.QuizBanners,
                Content = quizPage.Content,
            };
            ViewBag.QuizBanner = uow.QuizBannerRepository.GetAll();
            return View(viewmodel);
        }
    }
}