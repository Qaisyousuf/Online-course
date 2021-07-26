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
    public class OurVisionExplorationController : Controller
    {
        private readonly IUnitOfWork uow;

        public OurVisionExplorationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOurVisionExplorationData()
        {
            var ourVisionExploration = uow.OurVisionExplortaionRepository.GetAll();

            List<OurVisionExplationViewModel> viewmodel = new List<OurVisionExplationViewModel>();

            foreach (var item in ourVisionExploration)
            {
                viewmodel.Add(new OurVisionExplationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new OurVisionExplationViewModel());
        }

        [HttpPost]
        public ActionResult Create(OurVisionExplationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ourVisisonExploration = new OurVisionExplation
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                };

                uow.OurVisionExplortaionRepository.Add(ourVisisonExploration);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ourVisionExploration = uow.OurVisionExplortaionRepository.GetById(id);

            OurVisionExplationViewModel viewmodel = new OurVisionExplationViewModel
            {
                Id=ourVisionExploration.Id,
                MainTitle=ourVisionExploration.MainTitle,
                SubTitle=ourVisionExploration.SubTitle,
                Content=ourVisionExploration.Content,
                ImageUrl=ourVisionExploration.ImageUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OurVisionExplationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ourVisionexploration = uow.OurVisionExplortaionRepository.GetById(viewmodel.Id);

                ourVisionexploration.Id = viewmodel.Id;
                ourVisionexploration.MainTitle = viewmodel.MainTitle;
                ourVisionexploration.SubTitle = viewmodel.SubTitle;
                ourVisionexploration.Content = viewmodel.Content;
                ourVisionexploration.ImageUrl = viewmodel.ImageUrl;

                uow.OurVisionExplortaionRepository.Update(ourVisionexploration);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ourVisionExploration = uow.OurVisionExplortaionRepository.GetById(id);

            OurVisionExplationViewModel viewmodel = new OurVisionExplationViewModel
            {
                Id = ourVisionExploration.Id,
                MainTitle = ourVisionExploration.MainTitle,
                SubTitle = ourVisionExploration.SubTitle,
                Content = ourVisionExploration.Content,
                ImageUrl = ourVisionExploration.ImageUrl,
            };

            uow.OurVisionExplortaionRepository.Remove(ourVisionExploration);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ourVisionExploration = uow.OurVisionExplortaionRepository.GetById(id);

            OurVisionExplationViewModel viewmodel = new OurVisionExplationViewModel
            {
                Id = ourVisionExploration.Id,
                MainTitle = ourVisionExploration.MainTitle,
                SubTitle = ourVisionExploration.SubTitle,
                Content = ourVisionExploration.Content,
                ImageUrl = ourVisionExploration.ImageUrl,
            };
            return View(viewmodel);
        }
    }
}