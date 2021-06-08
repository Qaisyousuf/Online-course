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
    public class LearningModelController : Controller
    {
        private readonly IUnitOfWork uow;

        public LearningModelController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetLearningModelData()
        {
            var learningModel = uow.LearningModelRepository.GetAll();

            List<LearningModelViewModel> viewmodel = new List<LearningModelViewModel>();

            foreach (var item in learningModel)
            {
                viewmodel.Add(new LearningModelViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    IconUrl=item.IconUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new LearningModelViewModel());
        }

        [HttpPost]
        public ActionResult Create(LearningModelViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var learningModel = new LearningModel
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    IconUrl=viewmodel.IconUrl,
                };

                uow.LearningModelRepository.Add(learningModel);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)

        {
            var learningModel = uow.LearningModelRepository.GetById(id);

            LearningModelViewModel viewmodel = new LearningModelViewModel
            {
                Id=learningModel.Id,
                MainTitle=learningModel.MainTitle,
                Title=learningModel.Title,
                Content=learningModel.Content,
                IconUrl=learningModel.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(LearningModelViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var learningModel = uow.LearningModelRepository.GetById(viewmodel.Id);

                learningModel.Id = viewmodel.Id;
                learningModel.MainTitle = viewmodel.MainTitle;
                learningModel.Title = viewmodel.Title;
                learningModel.Content = viewmodel.Content;
                learningModel.IconUrl = viewmodel.IconUrl;

                uow.LearningModelRepository.Update(learningModel);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var learningModel = uow.LearningModelRepository.GetById(id);

            LearningModelViewModel viewmodel = new LearningModelViewModel
            {
                Id = learningModel.Id,
                MainTitle = learningModel.MainTitle,
                Title = learningModel.Title,
                Content = learningModel.Content,
                IconUrl = learningModel.IconUrl,
            };

            uow.LearningModelRepository.Remove(learningModel);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var learningModel = uow.LearningModelRepository.GetById(id);

            LearningModelViewModel viewmodel = new LearningModelViewModel
            {
                Id = learningModel.Id,
                MainTitle = learningModel.MainTitle,
                Title = learningModel.Title,
                Content = learningModel.Content,
                IconUrl = learningModel.IconUrl,
            };

            return View(viewmodel);
        }
    }
}