using Data.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class QuizQuestionController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizQuestionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/QuizQuestion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuizQuestionData()
        {
            var quizQuestion = uow.QuizQuestionRepository.GetAll();

            List<QuizQuestionViewModel> viewmodel = new List<QuizQuestionViewModel>();

            foreach (var item in quizQuestion)
            {
                viewmodel.Add(new QuizQuestionViewModel
                {
                    Id=item.Id,
                    QuestionsName=item.QuestionsName,
                    QuestoinContent=item.QuestoinContent,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuizQuestionViewModel());
        }


        [HttpPost]
        public ActionResult Create(QuizQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizQuestion = new QuizQuestion
                {
                    Id=viewmodel.Id,
                    QuestionsName=viewmodel.QuestionsName,
                    QuestoinContent=viewmodel.QuestoinContent,
                };

                uow.QuizQuestionRepository.Add(quizQuestion);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizQuestion = uow.QuizQuestionRepository.GetById(id);

            QuizQuestionViewModel viewmodel = new QuizQuestionViewModel
            {
                Id=quizQuestion.Id,
                QuestionsName=quizQuestion.QuestionsName,
                QuestoinContent=quizQuestion.QuestoinContent,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizQuestion = uow.QuizQuestionRepository.GetById(viewmodel.Id);

                quizQuestion.Id = viewmodel.Id;
                quizQuestion.QuestionsName = viewmodel.QuestionsName;
                quizQuestion.QuestoinContent = viewmodel.QuestoinContent;

                uow.QuizQuestionRepository.Update(quizQuestion);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizQuestion = uow.QuizQuestionRepository.GetById(id);

            QuizQuestionViewModel viewmodel = new QuizQuestionViewModel
            {
                Id=quizQuestion.Id,
                QuestionsName=quizQuestion.QuestionsName,
                QuestoinContent=quizQuestion.QuestoinContent,
            };

            uow.QuizQuestionRepository.Remove(quizQuestion);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizQuestion = uow.QuizQuestionRepository.GetById(id);

            QuizQuestionViewModel viewmodel = new QuizQuestionViewModel
            {
                Id = quizQuestion.Id,
                QuestionsName = quizQuestion.QuestionsName,
                QuestoinContent = quizQuestion.QuestoinContent,
            };

            return View(viewmodel);
        }
    }
}