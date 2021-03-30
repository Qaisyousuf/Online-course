using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Concrete_Implementation;
using Data.Interfaces;
using Model;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class ForLearnerController : Controller
    {
        private readonly IUnitOfWork uow;

        public ForLearnerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/ForLearner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetForLearnerData()
        {
            var forLearner = uow.ForLearnerRepository.GetAll();

            List<ForLearnerViewModel> viewmodel = new List<ForLearnerViewModel>();

            foreach (var item in forLearner)
            {
                viewmodel.Add(new ForLearnerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    ButtonText=item.ButtonText,
                    ButtonUrl=item.ButtonUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ForLearnerViewModel());
        }

        [HttpPost]
        public ActionResult Create(ForLearnerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var forLearner = new ForLearner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    ButtonText=viewmodel.ButtonText,
                    ButtonUrl=viewmodel.ButtonUrl,
                    Content=viewmodel.Content,
                };

                uow.ForLearnerRepository.Add(forLearner);
                uow.Commit();

            }

            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var forLearner = uow.ForLearnerRepository.GetById(id);

            ForLearnerViewModel viewmodel = new ForLearnerViewModel
            {
                Id=forLearner.Id,
                MainTitle=forLearner.MainTitle,
                Content=forLearner.Content,
                ButtonText=forLearner.ButtonText,
                ButtonUrl=forLearner.ButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(ForLearnerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var forLearner = uow.ForLearnerRepository.GetById(viewmodel.Id);

                forLearner.Id = viewmodel.Id;
                forLearner.MainTitle = viewmodel.MainTitle;
                forLearner.Content = viewmodel.Content;
                forLearner.ButtonText = viewmodel.ButtonText;
                forLearner.ButtonUrl = viewmodel.ButtonUrl;
                uow.ForLearnerRepository.Update(forLearner);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var forLearner = uow.ForLearnerRepository.GetById(id);

            ForLearnerViewModel viewmodel = new ForLearnerViewModel
            {
                Id=forLearner.Id,
                MainTitle=forLearner.MainTitle,
                Content=forLearner.Content,
                ButtonText=forLearner.ButtonText,
                ButtonUrl=forLearner.ButtonUrl,
            };
            uow.ForLearnerRepository.Remove(forLearner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var forLearner = uow.ForLearnerRepository.GetById(id);

            ForLearnerViewModel viewmodel = new ForLearnerViewModel
            {
                Id=forLearner.Id,
                MainTitle=forLearner.MainTitle,
                Content=forLearner.Content,
                ButtonText=forLearner.ButtonText,
                ButtonUrl=forLearner.ButtonUrl,

            };

            return View(viewmodel);
        }
    }
}