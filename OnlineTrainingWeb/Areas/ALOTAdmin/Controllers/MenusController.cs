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
    public class MenusController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            var menus = uow.MenuRepository.GetAll("Parent", "SubMenus");

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            foreach (var item in menus)
            {
                viewmodel.Add(new MenusViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Url = item.Url,
                    Parent = item.Parent,
                    ParentId = item.ParentId,
                    SubMenus = item.SubMenus,
                });
            }
            GetMenus();
            return View(viewmodel);
        }

        public void GetMenus()
        {
            ViewBag.SubMenus = uow.MenuRepository.GetAll();
        }

        [HttpGet]
        public JsonResult GetMenusData()
        {
            var menus = uow.MenuRepository.GetAll("Parent", "SubMenus");

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            foreach (var item in menus)
            {
                viewmodel.Add(new MenusViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Url = item.Url,
                    Parent = item.Parent,
                    ParentId = item.ParentId,
                    SubMenus = item.SubMenus,

                });
            }
            GetMenus();
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetMenus();
            return View(new MenusViewModel());
        }

        [HttpPost]
        public ActionResult Create(MenusViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var menus = new Menus
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Description = viewmodel.Description,
                    Url = viewmodel.Url,
                    Parent = viewmodel.Parent,
                    ParentId=viewmodel.ParentId,
                    SubMenus = viewmodel.SubMenus,
                };

                uow.MenuRepository.Add(menus);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
                Parent = menu.Parent,
                ParentId = menu.ParentId,
                SubMenus = menu.SubMenus,
            };

            GetMenus();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MenusViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var menus = uow.MenuRepository.GetById(viewmodel.Id);

                menus.Id = viewmodel.Id;
                menus.Title = viewmodel.Title;
                menus.Description = viewmodel.Description;
                menus.Url = viewmodel.Url;
                menus.Parent = viewmodel.Parent;
                menus.ParentId = viewmodel.ParentId;
                menus.SubMenus = viewmodel.SubMenus;

                uow.MenuRepository.Update(menus);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var menus = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id=menus.Id,
                Title=menus.Title,
                Description=menus.Description,
                Url=menus.Url,
                Parent=menus.Parent,
                ParentId=menus.ParentId,
                SubMenus=menus.SubMenus,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
                Parent = menu.Parent,
                ParentId = menu.ParentId,
                SubMenus = menu.SubMenus,
            };

            uow.MenuRepository.Remove(menu);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menu = uow.MenuRepository.GetById(id);
            MenusViewModel viewmodel = new MenusViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
                Parent = menu.Parent,
                ParentId = menu.ParentId,
                SubMenus = menu.SubMenus,
            };

            GetMenus();
            return View(viewmodel);
        }
    }
}