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
    public class TrainerPhilosophyController : Controller
    {
        private readonly IUnitOfWork uow;

        public TrainerPhilosophyController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTrainerPhilosophyData()
        {
            var trainerPhilosophy = uow.TrainerPhilosophyRepository.GetAll();

            List<TrainerPhilosophyViewModel> viewmodel = new List<TrainerPhilosophyViewModel>();

            foreach (var item in trainerPhilosophy)
            {
                viewmodel.Add(new TrainerPhilosophyViewModel
                {
                   Id=item.Id,
                   MainTitle=item.MainTitle,
                   Name=item.Name,
                   Content=item.Content,
                   ProfileImageUrl=item.ProfileImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TrainerPhilosophyViewModel());
        }

        [HttpPost]
        public ActionResult Create(TrainerPhilosophyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerPhilosophy = new TrainerPhilosophy
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Name=viewmodel.Name,
                    Content=viewmodel.Content,
                    ProfileImageUrl=viewmodel.ProfileImageUrl,
                };

                uow.TrainerPhilosophyRepository.Add(trainerPhilosophy);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var trainerPhilosophy = uow.TrainerPhilosophyRepository.GetById(id);

            TrainerPhilosophyViewModel viewmodel = new TrainerPhilosophyViewModel
            {
                Id=trainerPhilosophy.Id,
                MainTitle=trainerPhilosophy.MainTitle,
                Name=trainerPhilosophy.Name,
                Content=trainerPhilosophy.Content,
                ProfileImageUrl=trainerPhilosophy.ProfileImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TrainerPhilosophyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var trainerPhilosophy = uow.TrainerPhilosophyRepository.GetById(viewmodel.Id);

                trainerPhilosophy.Id = viewmodel.Id;
                trainerPhilosophy.MainTitle = viewmodel.MainTitle;
                trainerPhilosophy.Name = viewmodel.Name;
                trainerPhilosophy.Content = viewmodel.Content;
                trainerPhilosophy.ProfileImageUrl = viewmodel.ProfileImageUrl;

                uow.TrainerPhilosophyRepository.Update(trainerPhilosophy);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var trainerPhilosophy = uow.TrainerPhilosophyRepository.GetById(id);

            TrainerPhilosophyViewModel viewmodel = new TrainerPhilosophyViewModel
            {
                Id=trainerPhilosophy.Id,
                MainTitle=trainerPhilosophy.MainTitle,
                Content=trainerPhilosophy.Content,
                Name=trainerPhilosophy.Name,
                ProfileImageUrl=trainerPhilosophy.ProfileImageUrl,
            };

            uow.TrainerPhilosophyRepository.Remove(trainerPhilosophy);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var trainerPhilosophy = uow.TrainerPhilosophyRepository.GetById(id);

            TrainerPhilosophyViewModel viewmodel = new TrainerPhilosophyViewModel
            {
                Id = trainerPhilosophy.Id,
                MainTitle = trainerPhilosophy.MainTitle,
                Name = trainerPhilosophy.Name,
                Content = trainerPhilosophy.Content,
                ProfileImageUrl = trainerPhilosophy.ProfileImageUrl,
            };

            return View(viewmodel);
        }
    }
}