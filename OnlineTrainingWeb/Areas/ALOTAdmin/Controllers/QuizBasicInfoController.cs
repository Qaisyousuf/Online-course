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
    public class QuizBasicInfoController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuizBasicInfoController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            CountryData();
            return View();
        }

        [HttpGet]
        public ActionResult GetQuizBasicInfoData()
        {
            var quizBasicInfo = uow.QuizBasicInfoRepository.GetAll("CountryNames");

            List<QuizBasicInfoViewModel> viewmodel = new List<QuizBasicInfoViewModel>();

            foreach (var item in quizBasicInfo)
            {
                viewmodel.Add(new QuizBasicInfoViewModel
                {
                    Id=item.Id,
                    FullName=item.FullName,
                    Email=item.Email,
                    Mobile=item.Mobile,
                    CountryId=item.CountryId,
                    CountryNames=item.CountryNames,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        private void CountryData()
        {
            ViewBag.CountryNames = uow.CountryNamesRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CountryData();
            return View(new QuizBasicInfoViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuizBasicInfoViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizBasicInfo = new QuizBasicInfo
                {
                    Id=viewmodel.Id,
                    FullName=viewmodel.FullName,
                    Email=viewmodel.Email,
                    Mobile=viewmodel.Mobile,
                    CountryId=viewmodel.CountryId,
                    CountryNames=viewmodel.CountryNames,
                };

                uow.QuizBasicInfoRepository.Add(quizBasicInfo);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var quizBasicInfo = uow.QuizBasicInfoRepository.GetById(id);

            QuizBasicInfoViewModel viewmodel = new QuizBasicInfoViewModel
            {
                Id=quizBasicInfo.Id,
                FullName=quizBasicInfo.FullName,
                Email=quizBasicInfo.Email,
                Mobile=quizBasicInfo.Mobile,
                CountryId=quizBasicInfo.CountryId,
                CountryNames=quizBasicInfo.CountryNames,
            };

            CountryData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(QuizBasicInfoViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var quizBasicInfo = uow.QuizBasicInfoRepository.GetById(viewmodel.Id);

                quizBasicInfo.Id = viewmodel.Id;
                quizBasicInfo.FullName = viewmodel.FullName;
                quizBasicInfo.Email = viewmodel.Email;
                quizBasicInfo.Mobile = viewmodel.Mobile;
                quizBasicInfo.CountryId = viewmodel.CountryId;
                quizBasicInfo.CountryNames = viewmodel.CountryNames;

                uow.QuizBasicInfoRepository.Update(quizBasicInfo);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var quizBasicInfo = uow.QuizBasicInfoRepository.GetById(id);

            QuizBasicInfoViewModel viewmodel = new QuizBasicInfoViewModel
            {
                Id=quizBasicInfo.Id,
                FullName=quizBasicInfo.FullName,
                Email=quizBasicInfo.Email,
                Mobile=quizBasicInfo.Mobile,
               CountryId=quizBasicInfo.CountryId,
              CountryNames=quizBasicInfo.CountryNames,
            };

            uow.QuizBasicInfoRepository.Remove(quizBasicInfo);
            uow.Commit();

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var quizBasicInfo = uow.QuizBasicInfoRepository.GetById(id);

            QuizBasicInfoViewModel viewmodel = new QuizBasicInfoViewModel
            {
                Id = quizBasicInfo.Id,
                FullName = quizBasicInfo.FullName,
                Email = quizBasicInfo.Email,
                Mobile = quizBasicInfo.Mobile,
                CountryId = quizBasicInfo.CountryId,
                CountryNames = quizBasicInfo.CountryNames,
            };

            CountryData();
            return View(viewmodel);
        }
    }
}