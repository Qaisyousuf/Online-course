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
    public class TrainerIntroController : Controller
    {
        private readonly IUnitOfWork uow;
        public TrainerIntroController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTrainerIntroData()
        {
            var trainerIntro = uow.TrainerIntroRepository.GetAll();

            List<TrainerIntroViewModel> viewmodel = new List<TrainerIntroViewModel>();

            foreach (var item in trainerIntro)
            {
                viewmodel.Add(new TrainerIntroViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    AboutTrainer=item.AboutTrainer,
                    TrainerImageUrl=item.TrainerImageUrl,
                    TrainerAnimation=item.TrainerAnimation,
                    TrainerLocation=item.TrainerLocation,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TrainerIntroViewModel());
        }

        [HttpPost]
        public ActionResult Create(TrainerIntroViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerIntro = new TrainerIntro
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    TrainerLocation=viewmodel.TrainerLocation,
                    AboutTrainer=viewmodel.AboutTrainer,
                    TrainerImageUrl=viewmodel.TrainerImageUrl,
                    TrainerAnimation=viewmodel.TrainerAnimation,

                };

                uow.TrainerIntroRepository.Add(trainerIntro);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var trainerIntro = uow.TrainerIntroRepository.GetById(id);

            TrainerIntroViewModel viewmodel = new TrainerIntroViewModel
            {
                Id=trainerIntro.Id,
                Name=trainerIntro.Name,
                AboutTrainer=trainerIntro.AboutTrainer,
                TrainerImageUrl=trainerIntro.TrainerImageUrl,
                TrainerAnimation=trainerIntro.TrainerAnimation,
                TrainerLocation=trainerIntro.TrainerLocation,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TrainerIntroViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerIntro = uow.TrainerIntroRepository.GetById(viewmodel.Id);

                trainerIntro.Id = viewmodel.Id;
                trainerIntro.Name = viewmodel.Name;
                trainerIntro.AboutTrainer = viewmodel.AboutTrainer;
                trainerIntro.TrainerImageUrl = viewmodel.TrainerImageUrl;
                trainerIntro.TrainerAnimation = viewmodel.TrainerAnimation;
                trainerIntro.TrainerLocation = viewmodel.TrainerLocation;

                uow.TrainerIntroRepository.Update(trainerIntro);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var trainerIntro = uow.TrainerIntroRepository.GetById(id);

            TrainerIntroViewModel viewmodel = new TrainerIntroViewModel
            {
                Id=trainerIntro.Id,
                Name=trainerIntro.Name,
                TrainerLocation=trainerIntro.TrainerLocation,
                AboutTrainer=trainerIntro.AboutTrainer,
                TrainerAnimation=trainerIntro.TrainerAnimation,
                TrainerImageUrl=trainerIntro.TrainerImageUrl,
            };

            uow.TrainerIntroRepository.Remove(trainerIntro);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var trainerIntro = uow.TrainerIntroRepository.GetById(id);

            TrainerIntroViewModel viewmodel = new TrainerIntroViewModel
            {
                Id = trainerIntro.Id,
                Name = trainerIntro.Name,
                AboutTrainer = trainerIntro.AboutTrainer,
                TrainerImageUrl = trainerIntro.TrainerImageUrl,
                TrainerAnimation = trainerIntro.TrainerAnimation,
                TrainerLocation = trainerIntro.TrainerLocation,
            };

            return View(viewmodel);
        }
    }
}