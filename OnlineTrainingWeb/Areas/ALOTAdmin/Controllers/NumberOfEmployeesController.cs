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
    public class NumberOfEmployeesController : Controller
    {
        private readonly IUnitOfWork uow;

        public NumberOfEmployeesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNumberOfEmployeeData()
        {
            var numberOfEmployee = uow.EmployeesNumbersRepository.GetAll();

            List<EmplyeesViewModel> viewmodel = new List<EmplyeesViewModel>();

            foreach (var item in numberOfEmployee)
            {
                viewmodel.Add(new EmplyeesViewModel
                {
                    Id=item.Id,
                    NumberOfEmployee=item.NumberOfEmployee,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmplyeesViewModel());
        }

        [HttpPost]
        public ActionResult Create(EmplyeesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var numberOfEmployees = new Emplyees
                {
                    Id=viewmodel.Id,
                    NumberOfEmployee=viewmodel.NumberOfEmployee,
                };

                uow.EmployeesNumbersRepository.Add(numberOfEmployees);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var numberOfEmployees = uow.EmployeesNumbersRepository.GetById(id);

            EmplyeesViewModel viewmodel = new EmplyeesViewModel
            {
                Id=numberOfEmployees.Id,
                NumberOfEmployee=numberOfEmployees.NumberOfEmployee,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(EmplyeesViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var numberOfEmployees = uow.EmployeesNumbersRepository.GetById(viewmodel.Id);

                numberOfEmployees.Id = viewmodel.Id;
                numberOfEmployees.NumberOfEmployee = viewmodel.NumberOfEmployee;

                uow.EmployeesNumbersRepository.Update(numberOfEmployees);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var numberOfEmployees = uow.EmployeesNumbersRepository.GetById(id);

            EmplyeesViewModel viewmodel = new EmplyeesViewModel
            {
                Id = numberOfEmployees.Id,
                NumberOfEmployee = numberOfEmployees.NumberOfEmployee,
            };

            uow.EmployeesNumbersRepository.Remove(numberOfEmployees);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var numberOfEmployees = uow.EmployeesNumbersRepository.GetById(id);

            EmplyeesViewModel viewmodel = new EmplyeesViewModel
            {
                Id = numberOfEmployees.Id,
                NumberOfEmployee = numberOfEmployees.NumberOfEmployee,
            };

            return View(viewmodel);
        }
    }
}