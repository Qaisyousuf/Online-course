using Data;
using Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class RolesController : Controller
    {
        public RolesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        private readonly RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        private readonly IUnitOfWork uow;

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            var roles = uow.Context.Roles.ToList();

            List<RoleViewModel> viewmodel = new List<RoleViewModel>();

            foreach (var item in roles)
            {
                viewmodel.Add(new RoleViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole { Name = viewmodel.Name };

                var roleCrated = _roleManager.Create(role);

                if(roleCrated.Succeeded)
                {
                    return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ModelState.AddModelError("", roleCrated.Errors.FirstOrDefault());
                }
              
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var roleFromDb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=roleFromDb.Id,
                Name=roleFromDb.Name,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var roleFromdb = _roleManager.Roles.Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                roleFromdb.Name = viewmodel.Name;

                var roleUpdated = _roleManager.Update(roleFromdb);

                if(roleUpdated.Succeeded)
                {
                    return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ModelState.AddModelError("", roleUpdated.Errors.FirstOrDefault());
                }
            }
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var roleFromdb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            var roleDelete = _roleManager.Delete(roleFromdb);

            if(roleDelete.Succeeded)
            {
                return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError("", roleDelete.Errors.FirstOrDefault());
            }

            return RedirectToAction(nameof(Delete));
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var roleFromDb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id = roleFromDb.Id,
                Name = roleFromDb.Name,
            };

            return View(viewmodel);
        }
    }
}