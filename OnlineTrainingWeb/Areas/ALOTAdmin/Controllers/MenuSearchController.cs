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
    public class MenuSearchController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenuSearchController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSearchBoxData()
        {
            var searchbox = uow.MenuSearchBoxRepository.GetAll();

            List<MenuSearchBoxViewModel> viewmodel = new List<MenuSearchBoxViewModel>();

            foreach (var item in searchbox)
            {
                viewmodel.Add(new MenuSearchBoxViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Url=item.Url,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MenuSearchBoxViewModel());
        }

        [HttpPost]
        public ActionResult Create(MenuSearchBoxViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var searchMenu = new MenuSearchBox
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Url=viewmodel.Url,
                };


                uow.MenuSearchBoxRepository.Add(searchMenu);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var searchBox = uow.MenuSearchBoxRepository.GetById(id);

            MenuSearchBoxViewModel viewmodel = new MenuSearchBoxViewModel
            {
                Id=searchBox.Id,
                Name=searchBox.Name,
                Url=searchBox.Url,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MenuSearchBoxViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var searchbox = uow.MenuSearchBoxRepository.GetById(viewmodel.Id);

                searchbox.Id = viewmodel.Id;
                searchbox.Name = viewmodel.Name;
                searchbox.Url = viewmodel.Url;

                uow.MenuSearchBoxRepository.Update(searchbox);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var searchbox = uow.MenuSearchBoxRepository.GetById(id);

            MenuSearchBoxViewModel viewmodel = new MenuSearchBoxViewModel
            {
                Id=searchbox.Id,
                Name=searchbox.Name,
                Url=searchbox.Url,
            };

            uow.MenuSearchBoxRepository.Remove(searchbox);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var searchbox = uow.MenuSearchBoxRepository.GetById(id);

            MenuSearchBoxViewModel viewmodel = new MenuSearchBoxViewModel
            {
                Id=searchbox.Id,
                Name=searchbox.Name,
                Url=searchbox.Url,
            };

            return View(viewmodel);
        }
    }
}