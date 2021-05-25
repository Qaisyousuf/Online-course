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
    public class UpSkillingExplorationController : Controller
    {
        private readonly IUnitOfWork uow;

        public UpSkillingExplorationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUpSkillingExplorationData()
        {
            var upSkillingExploration = uow.UpskillingExplorationRepository.GetAll();

            List<UpskillingExplorationViewModel> viewmodel = new List<UpskillingExplorationViewModel>();

            foreach (var item in upSkillingExploration)
            {
                viewmodel.Add(new UpskillingExplorationViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    AnimationUrl=item.AnimationUrl,
                    Content=item.Content,
                    IconUlr=item.IconUlr,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UpskillingExplorationViewModel());
        }

        [HttpPost]
        public ActionResult Create(UpskillingExplorationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upskillingexploration = new UpskillingExploration
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    AnimationUrl=viewmodel.AnimationUrl,
                    Content=viewmodel.Content,
                    IconUlr=viewmodel.IconUlr,
                };
                uow.UpskillingExplorationRepository.Add(upskillingexploration);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var upskillingexploration = uow.UpskillingExplorationRepository.GetById(id);

            UpskillingExplorationViewModel viewmodel = new UpskillingExplorationViewModel
            {
                Id=upskillingexploration.Id,
                MainTitle=upskillingexploration.MainTitle,
                Title=upskillingexploration.Title,
                AnimationUrl=upskillingexploration.AnimationUrl,
                Content=upskillingexploration.Content,
                IconUlr=upskillingexploration.IconUlr,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UpskillingExplorationViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upskillingexploration = uow.UpskillingExplorationRepository.GetById(viewmodel.Id);

                upskillingexploration.Id = viewmodel.Id;
                upskillingexploration.MainTitle = viewmodel.MainTitle;
                upskillingexploration.Title = viewmodel.Title;
                upskillingexploration.AnimationUrl = viewmodel.AnimationUrl;
                upskillingexploration.Content = viewmodel.Content;
                upskillingexploration.IconUlr = viewmodel.IconUlr;

                uow.UpskillingExplorationRepository.Update(upskillingexploration);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var upskillingexploration = uow.UpskillingExplorationRepository.GetById(id);

            UpskillingExplorationViewModel viewmodel = new UpskillingExplorationViewModel
            {
                Id=upskillingexploration.Id,
                MainTitle=upskillingexploration.MainTitle,
                Title=upskillingexploration.Title,
                AnimationUrl=upskillingexploration.AnimationUrl,
                Content=upskillingexploration.Content,
                IconUlr=upskillingexploration.IconUlr,
            };
            uow.UpskillingExplorationRepository.Remove(upskillingexploration);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var upskillingexploration = uow.UpskillingExplorationRepository.GetById(id);

            UpskillingExplorationViewModel viewmodel = new UpskillingExplorationViewModel
            {
                Id = upskillingexploration.Id,
                MainTitle = upskillingexploration.MainTitle,
                Title = upskillingexploration.Title,
                AnimationUrl = upskillingexploration.AnimationUrl,
                Content = upskillingexploration.Content,
                IconUlr = upskillingexploration.IconUlr,
            };

            return View(viewmodel);
        }
    }
}