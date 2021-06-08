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
    public class UpSkillingEmployeeController : Controller
    {
        private readonly IUnitOfWork uow;

        public UpSkillingEmployeeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUpSkillingEmployeeData()
        {
            var upSkillingEmployee = uow.UpSkillingEmployeesRepository.GetAll();

            List<UpskillingEmployeeViewModel> viewmodel = new List<UpskillingEmployeeViewModel>();

            foreach (var item in upSkillingEmployee)
            {
                viewmodel.Add(new UpskillingEmployeeViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    TalkToExpertButton=item.TalkToExpertButton,
                    TalkToExpertButtonUrl=item.TalkToExpertButtonUrl,
                    IllstrationUrl=item.IllstrationUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UpskillingEmployeeViewModel());
        }

        [HttpPost]
        public ActionResult Create(UpskillingEmployeeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upSkillingEmployee = new UpskillingEmployee
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Content=viewmodel.Content,
                    TalkToExpertButton=viewmodel.TalkToExpertButton,
                    TalkToExpertButtonUrl=viewmodel.TalkToExpertButtonUrl,
                    IllstrationUrl=viewmodel.IllstrationUrl,
                };

                uow.UpSkillingEmployeesRepository.Add(upSkillingEmployee);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var upSkillingEmployee = uow.UpSkillingEmployeesRepository.GetById(id);

            UpskillingEmployeeViewModel viewmodel = new UpskillingEmployeeViewModel
            {
                Id=upSkillingEmployee.Id,
                MainTitle=upSkillingEmployee.MainTitle,
                Content=upSkillingEmployee.Content,
                TalkToExpertButton=upSkillingEmployee.TalkToExpertButton,
                TalkToExpertButtonUrl=upSkillingEmployee.TalkToExpertButtonUrl,
                IllstrationUrl=upSkillingEmployee.IllstrationUrl,
            };

            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(UpskillingEmployeeViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var upSkillingEmployee = uow.UpSkillingEmployeesRepository.GetById(viewmodel.Id);

                upSkillingEmployee.Id = viewmodel.Id;
                upSkillingEmployee.MainTitle = viewmodel.MainTitle;
                upSkillingEmployee.Content = viewmodel.Content;
                upSkillingEmployee.TalkToExpertButtonUrl = viewmodel.TalkToExpertButtonUrl;
                upSkillingEmployee.TalkToExpertButton = viewmodel.TalkToExpertButton;
                upSkillingEmployee.IllstrationUrl = viewmodel.IllstrationUrl;

                uow.UpSkillingEmployeesRepository.Update(upSkillingEmployee);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var upSkillingEmployee = uow.UpSkillingEmployeesRepository.GetById(id);

            UpskillingEmployeeViewModel viewmodel = new UpskillingEmployeeViewModel
            {
                Id = upSkillingEmployee.Id,
                MainTitle = upSkillingEmployee.MainTitle,
                Content = upSkillingEmployee.Content,
                TalkToExpertButton = upSkillingEmployee.TalkToExpertButton,
                TalkToExpertButtonUrl = upSkillingEmployee.TalkToExpertButtonUrl,
                IllstrationUrl = upSkillingEmployee.IllstrationUrl,
            };

            uow.UpSkillingEmployeesRepository.Remove(upSkillingEmployee);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var upSkillingEmployee = uow.UpSkillingEmployeesRepository.GetById(id);

            UpskillingEmployeeViewModel viewmodel = new UpskillingEmployeeViewModel
            {
                Id = upSkillingEmployee.Id,
                MainTitle = upSkillingEmployee.MainTitle,
                Content = upSkillingEmployee.Content,
                TalkToExpertButton = upSkillingEmployee.TalkToExpertButton,
                TalkToExpertButtonUrl = upSkillingEmployee.TalkToExpertButtonUrl,
                IllstrationUrl = upSkillingEmployee.IllstrationUrl,
            };

            return View(viewmodel);
        }

    }
}