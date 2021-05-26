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
    public class TrustedbyForUpSkillingController : Controller
    {
        private readonly IUnitOfWork uow;

        public TrustedbyForUpSkillingController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTurstedByUpSkillingData()
        {
            var trustedByUpSkilling = uow.TrustedbyForUpSkillingRepository.GetAll();

            List<TrustedbyForUpSkillingViewModel> viewmodel = new List<TrustedbyForUpSkillingViewModel>();

            foreach (var item in trustedByUpSkilling)
            {
                viewmodel.Add(new TrustedbyForUpSkillingViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    AnimationUrl=item.AnimationUrl,
                    LogoUrl=item.LogoUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TrustedbyForUpSkillingViewModel());
        }

        [HttpPost]
        public ActionResult Create(TrustedbyForUpSkillingViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var truestedUpskilling = new TrustedbyForUpSkilling
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    AnimationUrl=viewmodel.AnimationUrl,
                    LogoUrl=viewmodel.LogoUrl,
                };

                uow.TrustedbyForUpSkillingRepository.Add(truestedUpskilling);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var truestedUpskilling = uow.TrustedbyForUpSkillingRepository.GetById(id);

            TrustedbyForUpSkillingViewModel viewmodel = new TrustedbyForUpSkillingViewModel
            {
                Id=truestedUpskilling.Id,
                MainTitle=truestedUpskilling.MainTitle,
                Title=truestedUpskilling.Title,
                AnimationUrl=truestedUpskilling.AnimationUrl,
                LogoUrl=truestedUpskilling.LogoUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TrustedbyForUpSkillingViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var truestedUpskilling = uow.TrustedbyForUpSkillingRepository.GetById(viewmodel.Id);

                truestedUpskilling.Id = viewmodel.Id;
                truestedUpskilling.MainTitle = viewmodel.MainTitle;
                truestedUpskilling.Title = viewmodel.Title;
                truestedUpskilling.AnimationUrl = viewmodel.AnimationUrl;
                truestedUpskilling.LogoUrl = viewmodel.LogoUrl;

                uow.TrustedbyForUpSkillingRepository.Update(truestedUpskilling);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var truestedUpskilling = uow.TrustedbyForUpSkillingRepository.GetById(id);

            TrustedbyForUpSkillingViewModel viewmodel = new TrustedbyForUpSkillingViewModel
            {
                Id = truestedUpskilling.Id,
                MainTitle = truestedUpskilling.MainTitle,
                Title = truestedUpskilling.Title,
                AnimationUrl = truestedUpskilling.AnimationUrl,
                LogoUrl = truestedUpskilling.LogoUrl,
            };

            uow.TrustedbyForUpSkillingRepository.Remove(truestedUpskilling);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var truestedUpskilling = uow.TrustedbyForUpSkillingRepository.GetById(id);

            TrustedbyForUpSkillingViewModel viewmodel = new TrustedbyForUpSkillingViewModel
            {
                Id = truestedUpskilling.Id,
                MainTitle = truestedUpskilling.MainTitle,
                Title = truestedUpskilling.Title,
                AnimationUrl = truestedUpskilling.AnimationUrl,
                LogoUrl = truestedUpskilling.LogoUrl,
            };

            return View(viewmodel);
        }
    }
}