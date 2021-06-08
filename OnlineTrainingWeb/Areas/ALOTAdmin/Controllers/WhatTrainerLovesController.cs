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
    public class WhatTrainerLovesController : Controller
    {
        private readonly IUnitOfWork uow;

        public WhatTrainerLovesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetWhatTrainerLovesData()
        {
            var whatTrainerLoves = uow.WhatTrainerLovesRepository.GetAll();

            List<WhatTrainerLovesViewModel> viewmodel = new List<WhatTrainerLovesViewModel>();

            foreach (var item in whatTrainerLoves)
            {
                viewmodel.Add(new WhatTrainerLovesViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    IconUrl=item.IconUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new WhatTrainerLovesViewModel());
        }

        [HttpPost]
        public ActionResult Create(WhatTrainerLovesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var whatTrainerLoves = new WhatTrainerLoves
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    IconUrl=viewmodel.IconUrl,
                };

                uow.WhatTrainerLovesRepository.Add(whatTrainerLoves);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var whatTrainerLoves = uow.WhatTrainerLovesRepository.GetById(id);

            WhatTrainerLovesViewModel viewmodel = new WhatTrainerLovesViewModel
            {
                Id=whatTrainerLoves.Id,
                MainTitle=whatTrainerLoves.MainTitle,
                Title=whatTrainerLoves.Title,
                IconUrl=whatTrainerLoves.IconUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(WhatTrainerLovesViewModel viewmodoel)
        {
            if(ModelState.IsValid)
            {
                var whatTrainerLoves = uow.WhatTrainerLovesRepository.GetById(viewmodoel.Id);

                whatTrainerLoves.Id = viewmodoel.Id;
                whatTrainerLoves.MainTitle = viewmodoel.MainTitle;
                whatTrainerLoves.Title = viewmodoel.Title;
                whatTrainerLoves.IconUrl = viewmodoel.IconUrl;

                uow.WhatTrainerLovesRepository.Update(whatTrainerLoves);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var whatTrainerLoves = uow.WhatTrainerLovesRepository.GetById(id);

            WhatTrainerLovesViewModel viewmodel = new WhatTrainerLovesViewModel
            {
                Id=whatTrainerLoves.Id,
                MainTitle=whatTrainerLoves.MainTitle,
                Title=whatTrainerLoves.Title,
                IconUrl=whatTrainerLoves.IconUrl,
            };

            uow.WhatTrainerLovesRepository.Remove(whatTrainerLoves);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)

        {
            var whatTrainerLoves = uow.WhatTrainerLovesRepository.GetById(id);

            WhatTrainerLovesViewModel viewmodel = new WhatTrainerLovesViewModel
            {
                Id = whatTrainerLoves.Id,
                MainTitle = whatTrainerLoves.MainTitle,
                Title = whatTrainerLoves.Title,
                IconUrl = whatTrainerLoves.IconUrl,
            };

            return View(viewmodel);
        }
    }
}