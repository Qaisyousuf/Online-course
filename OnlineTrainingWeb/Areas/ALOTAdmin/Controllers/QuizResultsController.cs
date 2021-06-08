using Data.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class QuizResultsController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizResultsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetQuizResultsData()
        {
            var quizResults = uow.QuizResultsRepository.GetAll();

            List<QuizResultsViewModel> viewmodel = new List<QuizResultsViewModel>();

            foreach (var item in quizResults)
            {
                viewmodel.Add(new QuizResultsViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ResultRecomandation=item.ResultRecomandation,
                    JoinBtn=item.JoinBtn,
                    JoinBtnUrl=item.JoinBtnUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new QuizResultsViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuizResultsViewModel ViewModel)
        {
            if(ModelState.IsValid)
            {
                var quizResults = new QuizResults
                {
                    Id=ViewModel.Id,
                    Title=ViewModel.Title,
                    Content=ViewModel.Content,
                    ResultRecomandation=ViewModel.ResultRecomandation,
                    JoinBtn=ViewModel.JoinBtn,
                    JoinBtnUrl=ViewModel.JoinBtnUrl,
                };

                uow.QuizResultsRepository.Add(quizResults);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizResults = uow.QuizResultsRepository.GetById(id);

            QuizResultsViewModel viewmodel = new QuizResultsViewModel
            {
                Id=quizResults.Id,
                Title=quizResults.Title,
                Content=quizResults.Content,
                ResultRecomandation=quizResults.ResultRecomandation,
                JoinBtn=quizResults.JoinBtn,
                JoinBtnUrl=quizResults.JoinBtnUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizResultsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizResults = uow.QuizResultsRepository.GetById(viewmodel.Id);

                quizResults.Id = viewmodel.Id;
                quizResults.Title = viewmodel.Title;
                quizResults.ResultRecomandation = viewmodel.ResultRecomandation;
                quizResults.JoinBtn = viewmodel.JoinBtn;
                quizResults.JoinBtnUrl = viewmodel.JoinBtnUrl;
                quizResults.Content = viewmodel.Content;

                uow.QuizResultsRepository.Update(quizResults);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizResults = uow.QuizResultsRepository.GetById(id);

            QuizResultsViewModel viewmodel = new QuizResultsViewModel
            {
                Id=quizResults.Id,
                Title=quizResults.Title,
                Content=quizResults.Content,
                ResultRecomandation=quizResults.ResultRecomandation,
                JoinBtn=quizResults.JoinBtn,
                JoinBtnUrl=quizResults.JoinBtnUrl,
            };

            uow.QuizResultsRepository.Remove(quizResults);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizResults = uow.QuizResultsRepository.GetById(id);

            QuizResultsViewModel viewmodel = new QuizResultsViewModel
            {
                Id=quizResults.Id,
                Title=quizResults.Title,
                ResultRecomandation=quizResults.ResultRecomandation,
                Content=quizResults.Content,
                JoinBtn=quizResults.JoinBtn,
                JoinBtnUrl=quizResults.JoinBtnUrl,

            };

            return View(viewmodel);
        }
    }
}