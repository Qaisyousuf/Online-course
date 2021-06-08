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
    public class OnlineTrainingBenefitsController : Controller
    {
        private readonly IUnitOfWork uow;

        public OnlineTrainingBenefitsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOnlineTrainingBenefitsData()
        {
            var onlineTrainingBenefits = uow.OnlinetrainingbenefitsRepository.GetAll();

            List<OnlinetrainingbenefitsViewModel> viewmodel = new List<OnlinetrainingbenefitsViewModel>();

            foreach (var item in onlineTrainingBenefits)
            {
                viewmodel.Add(new OnlinetrainingbenefitsViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    ImageUrl=item.ImageUrl,
                    AnimationUrl=item.AnimationUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new OnlinetrainingbenefitsViewModel());
        }

        [HttpPost]
        public ActionResult Create(OnlinetrainingbenefitsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var onlineTrainingBenefits = new Onlinetrainingbenefits
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    ImageUrl=viewmodel.ImageUrl,
                    AnimationUrl=viewmodel.AnimationUrl,
                };

                uow.OnlinetrainingbenefitsRepository.Add(onlineTrainingBenefits);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var onlineTrainingBenefits = uow.OnlinetrainingbenefitsRepository.GetById(id);

            OnlinetrainingbenefitsViewModel viewmodel = new OnlinetrainingbenefitsViewModel
            {
                Id=onlineTrainingBenefits.Id,
                MainTitle=onlineTrainingBenefits.MainTitle,
                SubTitle=onlineTrainingBenefits.SubTitle,
                Content=onlineTrainingBenefits.Content,
                ImageUrl=onlineTrainingBenefits.ImageUrl,
                AnimationUrl=onlineTrainingBenefits.AnimationUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OnlinetrainingbenefitsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var onlineTrainingBenefits = uow.OnlinetrainingbenefitsRepository.GetById(viewmodel.Id);

                onlineTrainingBenefits.Id = viewmodel.Id;
                onlineTrainingBenefits.MainTitle = viewmodel.MainTitle;
                onlineTrainingBenefits.SubTitle = viewmodel.SubTitle;
                onlineTrainingBenefits.Content = viewmodel.Content;
                onlineTrainingBenefits.AnimationUrl = viewmodel.AnimationUrl;
                onlineTrainingBenefits.ImageUrl = viewmodel.ImageUrl;

                uow.OnlinetrainingbenefitsRepository.Update(onlineTrainingBenefits);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var onlineTrainingBenefits = uow.OnlinetrainingbenefitsRepository.GetById(id);

            OnlinetrainingbenefitsViewModel viewmodel = new OnlinetrainingbenefitsViewModel
            {
                Id=onlineTrainingBenefits.Id,
                MainTitle=onlineTrainingBenefits.MainTitle,
                SubTitle=onlineTrainingBenefits.SubTitle,
                Content=onlineTrainingBenefits.Content,
                ImageUrl=onlineTrainingBenefits.ImageUrl,
                AnimationUrl=onlineTrainingBenefits.AnimationUrl,
            };

            uow.OnlinetrainingbenefitsRepository.Remove(onlineTrainingBenefits);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var onlineTrainingBenefits = uow.OnlinetrainingbenefitsRepository.GetById(id);

            OnlinetrainingbenefitsViewModel viewmodel = new OnlinetrainingbenefitsViewModel
            {
                Id = onlineTrainingBenefits.Id,
                MainTitle = onlineTrainingBenefits.MainTitle,
                SubTitle = onlineTrainingBenefits.SubTitle,
                Content = onlineTrainingBenefits.Content,
                ImageUrl = onlineTrainingBenefits.ImageUrl,
                AnimationUrl = onlineTrainingBenefits.AnimationUrl,
            };

            return View(viewmodel);
        }

    }
}