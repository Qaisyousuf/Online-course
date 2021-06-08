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
    public class UpSkillingImportanceController : Controller
    {
        private readonly IUnitOfWork uow;

        public UpSkillingImportanceController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUpSkillingImportanceData()
        {
            var upSkillingImportance = uow.UpskillingImportanceRepository.GetAll();

            List<UpskillingImportanceViewModel> viewmodoel = new List<UpskillingImportanceViewModel>();

            foreach (var item in upSkillingImportance)
            {
                viewmodoel.Add(new UpskillingImportanceViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Animation=item.Animation,
                    RegisterButton=item.RegisterButton,
                    RegisterButtonUrl=item.RegisterButtonUrl,
                    ContactButton=item.ContactButton,
                    ContactButtonUrl=item.ContactButtonUrl,
                });
            }

            return Json(new { data = viewmodoel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UpskillingImportanceViewModel());
        }

        [HttpPost]
        public ActionResult Create(UpskillingImportanceViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upskillingImportance = new UpskillingImportance
                {
                    Id = viewmodel.Id,
                    MainTitle = viewmodel.MainTitle,
                    Title = viewmodel.Title,
                    Animation = viewmodel.Animation,
                    RegisterButton = viewmodel.RegisterButton,
                    RegisterButtonUrl = viewmodel.RegisterButtonUrl,
                    ContactButton = viewmodel.ContactButton,
                    ContactButtonUrl = viewmodel.ContactButtonUrl,

                };

                uow.UpskillingImportanceRepository.Add(upskillingImportance);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var upSkillingImportance = uow.UpskillingImportanceRepository.GetById(id);

            UpskillingImportanceViewModel viewmodel = new UpskillingImportanceViewModel
            {
                Id=upSkillingImportance.Id,
                MainTitle=upSkillingImportance.MainTitle,
                Title=upSkillingImportance.Title,
                Animation=upSkillingImportance.Animation,
                RegisterButton=upSkillingImportance.RegisterButton,
                RegisterButtonUrl=upSkillingImportance.RegisterButtonUrl,
                ContactButton=upSkillingImportance.ContactButton,
                ContactButtonUrl=upSkillingImportance.ContactButtonUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UpskillingImportanceViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upSkillingImportance = uow.UpskillingImportanceRepository.GetById(viewmodel.Id);

                upSkillingImportance.Id = viewmodel.Id;
                upSkillingImportance.MainTitle = viewmodel.MainTitle;
                upSkillingImportance.Title = viewmodel.Title;
                upSkillingImportance.Animation = viewmodel.Animation;
                upSkillingImportance.RegisterButton = viewmodel.RegisterButton;
                upSkillingImportance.RegisterButtonUrl = viewmodel.RegisterButtonUrl;
                upSkillingImportance.ContactButton = viewmodel.ContactButton;
                upSkillingImportance.ContactButtonUrl = viewmodel.ContactButtonUrl;

                uow.UpskillingImportanceRepository.Update(upSkillingImportance);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var upSkillingImportance = uow.UpskillingImportanceRepository.GetById(id);

            UpskillingImportanceViewModel viewmodel = new UpskillingImportanceViewModel
            {
               Id=upSkillingImportance.Id,
               MainTitle=upSkillingImportance.MainTitle,
               Title=upSkillingImportance.Title,
               Animation=upSkillingImportance.Animation,
               RegisterButton=upSkillingImportance.RegisterButton,
               RegisterButtonUrl=upSkillingImportance.RegisterButtonUrl,
               ContactButton=upSkillingImportance.ContactButton,
               ContactButtonUrl=upSkillingImportance.ContactButtonUrl,
            };

            uow.UpskillingImportanceRepository.Remove(upSkillingImportance);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var upskillingimportance = uow.UpskillingImportanceRepository.GetById(id);

            UpskillingImportanceViewModel viewmodel = new UpskillingImportanceViewModel
            {
                Id=upskillingimportance.Id,
                MainTitle=upskillingimportance.MainTitle,
                Title=upskillingimportance.Title,
                Animation=upskillingimportance.Animation,
                RegisterButton=upskillingimportance.RegisterButton,
                RegisterButtonUrl=upskillingimportance.RegisterButtonUrl,
                ContactButton=upskillingimportance.ContactButton,
                ContactButtonUrl=upskillingimportance.ContactButtonUrl,
            };

            return View(viewmodel);
        }
    }
}