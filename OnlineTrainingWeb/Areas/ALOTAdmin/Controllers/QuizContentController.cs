using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Model;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class QuizContentController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizContentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetQuizContentData()
        {
            var quizContent = uow.QuizContentRepository.GetAll();

            List<QuizContentViewModel> viewmodel = new List<QuizContentViewModel>();

            foreach (var item in quizContent)
            {
                viewmodel.Add(new QuizContentViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuizContentViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuizContentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizContent = new QuizContent
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                };

                uow.QuizContentRepository.Add(quizContent);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizContetn = uow.QuizContentRepository.GetById(id);

            QuizContentViewModel viewmodel = new QuizContentViewModel
            {
                Id=quizContetn.Id,
                MainTitle=quizContetn.MainTitle,
                Content=quizContetn.Content,
                ImageUrl=quizContetn.ImageUrl,
                ButtonText=quizContetn.ButtonText,
                ButtonUrl=quizContetn.ButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizContentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizContent = uow.QuizContentRepository.GetById(viewmodel.Id);

                quizContent.Id = viewmodel.Id;
                quizContent.MainTitle = viewmodel.MainTitle;
                quizContent.Content = viewmodel.Content;
                quizContent.ImageUrl = viewmodel.ImageUrl;
                quizContent.ButtonText = viewmodel.ButtonText;
                quizContent.ButtonUrl = viewmodel.ButtonUrl;

                uow.QuizContentRepository.Update(quizContent);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizContent = uow.QuizContentRepository.GetById(id);

            QuizContentViewModel viewmodel = new QuizContentViewModel
            {
                Id=quizContent.Id,
                MainTitle=quizContent.MainTitle,
                Content=quizContent.Content,
                ImageUrl=quizContent.ImageUrl,
                ButtonText=quizContent.ButtonText,
                ButtonUrl=quizContent.ButtonUrl,
            };

            uow.QuizContentRepository.Remove(quizContent);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizContetn = uow.QuizContentRepository.GetById(id);

            QuizContentViewModel viewmodel = new QuizContentViewModel
            {
                Id = quizContetn.Id,
                MainTitle = quizContetn.MainTitle,
                Content = quizContetn.Content,
                ImageUrl = quizContetn.ImageUrl,
                ButtonText = quizContetn.ButtonText,
                ButtonUrl = quizContetn.ButtonUrl,
            };

            return View(viewmodel);
        }
    }
}