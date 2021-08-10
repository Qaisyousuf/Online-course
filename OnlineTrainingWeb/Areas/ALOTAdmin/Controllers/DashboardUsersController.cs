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
    public class DashboardUsersController : Controller
    {
        private readonly IUnitOfWork uow;

        public DashboardUsersController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/DashboardUsers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDashBoardUsersData()
        {
            var dashboardUser = uow.DashboardUserRepository.GetAll();

            List<DashboardUsersViewModel> viewmodel = new List<DashboardUsersViewModel>();

            foreach (var item in dashboardUser)
            {
                viewmodel.Add(new DashboardUsersViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Content=item.Content,
                    AnimationLink=item.AnimationLink,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DashboardUsersViewModel());
        }

        [HttpPost]
        public ActionResult Create(DashboardUsersViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var dashboard = new DashboardUsers
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    AnimationLink=viewmodel.AnimationLink,
                };

                uow.DashboardUserRepository.Add(dashboard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dashboard = uow.DashboardUserRepository.GetById(id);

            DashboardUsersViewModel viewmodel = new DashboardUsersViewModel
            {
                Id=dashboard.Id,
                MainTitle=dashboard.MainTitle,
                Title=dashboard.Title,
                Content=dashboard.Content,
                AnimationLink=dashboard.AnimationLink,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(DashboardUsersViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var dashboard = uow.DashboardUserRepository.GetById(viewmodel.Id);

                dashboard.Id = viewmodel.Id;
                dashboard.MainTitle = viewmodel.MainTitle;
                dashboard.Title = viewmodel.Title;
                dashboard.Content = viewmodel.Content;
                dashboard.AnimationLink = viewmodel.AnimationLink;

                uow.DashboardUserRepository.Update(dashboard);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dashboard = uow.DashboardUserRepository.GetById(id);

            DashboardUsersViewModel viewmodel = new DashboardUsersViewModel
            {
                Id = dashboard.Id,
                MainTitle = dashboard.MainTitle,
                Title = dashboard.Title,
                Content = dashboard.Content,
                AnimationLink = dashboard.AnimationLink,
            };

            uow.DashboardUserRepository.Remove(dashboard);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dashboard = uow.DashboardUserRepository.GetById(id);

            DashboardUsersViewModel viewmodel = new DashboardUsersViewModel
            {
                Id = dashboard.Id,
                MainTitle = dashboard.MainTitle,
                Title = dashboard.Title,
                Content = dashboard.Content,
                AnimationLink = dashboard.AnimationLink,
            };

            return View(viewmodel);
        }
    }
}