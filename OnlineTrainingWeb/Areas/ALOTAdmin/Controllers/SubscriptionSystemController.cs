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
    public class SubscriptionSystemController : Controller
    {
        private readonly IUnitOfWork uow;

        public SubscriptionSystemController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSubscriptionSystemData()
        {
            var subscriptionSystem = uow.SubscriptionSystemRepository.GetAll();

            List<SubscriptionSystemViewModel> viewmodel = new List<SubscriptionSystemViewModel>();

            foreach (var item in subscriptionSystem)
            {
                viewmodel.Add(new SubscriptionSystemViewModel
                {
                    Id=item.Id,
                    Email=item.Email,
                    UserName=item.UserName,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var subscriptionSystem = uow.SubscriptionSystemRepository.GetById(id);

            SubscriptionSystemViewModel viewmodel = new SubscriptionSystemViewModel
            {
                Id=subscriptionSystem.Id,
                UserName=subscriptionSystem.UserName,
                Email=subscriptionSystem.Email,
            };

            uow.SubscriptionSystemRepository.Remove(subscriptionSystem);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var subscriptionSystem = uow.SubscriptionSystemRepository.GetById(id);

            SubscriptionSystemViewModel viewmodel = new SubscriptionSystemViewModel
            {
                Id = subscriptionSystem.Id,
                UserName = subscriptionSystem.UserName,
                Email = subscriptionSystem.Email,
            };

            return View(viewmodel);
        }
    }
}