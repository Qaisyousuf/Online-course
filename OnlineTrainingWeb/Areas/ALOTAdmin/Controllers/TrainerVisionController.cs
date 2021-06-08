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
    public class TrainerVisionController : Controller
    {
        private readonly IUnitOfWork uow;

        public TrainerVisionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTrainerVisionData()
        {
            var trainerVision = uow.TrainerVisionRepository.GetAll();

            List<TrainerVisionViewModel> viewmodel = new List<TrainerVisionViewModel>();

            foreach (var item in trainerVision)
            {
                viewmodel.Add(new TrainerVisionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ProfileImageUrl=item.ProfileImageUrl,
                    TrainerName=item.TrainerName,
                    BestRegards=item.BestRegards,
                });

               
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TrainerVisionViewModel());
        }

        [HttpPost]
        public ActionResult Create(TrainerVisionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerVision = new TrainerVision
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    ProfileImageUrl=viewmodel.ProfileImageUrl,
                    TrainerName=viewmodel.TrainerName,
                    BestRegards=viewmodel.BestRegards,
                };

                uow.TrainerVisionRepository.Add(trainerVision);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var trainerVision = uow.TrainerVisionRepository.GetById(id);

            TrainerVisionViewModel viewmodel = new TrainerVisionViewModel
            {
                Id=trainerVision.Id,
                Title=trainerVision.Title,
                ProfileImageUrl=trainerVision.ProfileImageUrl,
                Content=trainerVision.Content,
                TrainerName=trainerVision.TrainerName,
                BestRegards=trainerVision.BestRegards,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TrainerVisionViewModel viewmoodel)
        {
            if(ModelState.IsValid)
            {
                var trainerVision = uow.TrainerVisionRepository.GetById(viewmoodel.Id);

                trainerVision.Id = viewmoodel.Id;
                trainerVision.Title = viewmoodel.Title;
                trainerVision.Content = viewmoodel.Content;
                trainerVision.ProfileImageUrl = viewmoodel.ProfileImageUrl;
                trainerVision.TrainerName = viewmoodel.TrainerName;
                trainerVision.BestRegards = viewmoodel.BestRegards;

                uow.TrainerVisionRepository.Update(trainerVision);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var trainerVision = uow.TrainerVisionRepository.GetById(id);

            TrainerVisionViewModel viewmodel = new TrainerVisionViewModel
            {
                Id=trainerVision.Id,
                Title=trainerVision.Title,
                Content=trainerVision.Content,
                TrainerName=trainerVision.TrainerName,
                ProfileImageUrl=trainerVision.ProfileImageUrl,
                BestRegards=trainerVision.BestRegards,
            };

            uow.TrainerVisionRepository.Remove(trainerVision);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var trainerVision = uow.TrainerVisionRepository.GetById(id);

            TrainerVisionViewModel viewmodel = new TrainerVisionViewModel
            {
                Id = trainerVision.Id,
                Title = trainerVision.Title,
                ProfileImageUrl = trainerVision.ProfileImageUrl,
                Content = trainerVision.Content,
                TrainerName = trainerVision.TrainerName,
                BestRegards = trainerVision.BestRegards,
            };

            return View(viewmodel);
        }
    }
}