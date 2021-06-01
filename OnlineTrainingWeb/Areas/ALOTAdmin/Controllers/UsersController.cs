using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Model;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleMange = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserData()
        {
            List<ShowUserViewModel> showViewmodel = new List<ShowUserViewModel>();
            var user = UserManager.Users.ToList();

            var userRoleIds = new List<string>();
            var roleName = new List<string>();

            foreach (var item in user)
            {
                userRoleIds = item.Roles.Select(x => x.RoleId).ToList();

                roleName = _roleMange.Roles.Where(x => userRoleIds.Contains(x.Id)).Select(x => x.Name).ToList();
                showViewmodel.Add(new ShowUserViewModel
                {
                    Id=item.Id,Email=item.Email,FullName=item.FullName,CreatedDate=item.CreatedData
                });
            }

            return Json(new { data = showViewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            InsertUserViewModel insertUser = new InsertUserViewModel();

           

            var roleFromd = _roleMange.Roles.ToList();
            List<CheckBoxItemViewModel> checkBoxListitem = new List<CheckBoxItemViewModel>();

            foreach (var item in roleFromd)
            {
                checkBoxListitem.Add(new CheckBoxItemViewModel
                {
                    Id=item.Id,Text=item.Name,Checked=false
                });

            }
            insertUser.Roles = checkBoxListitem;
            return View(insertUser);

        }

        private EditUsersViewModel GetEditUsers(string id)
        {
            var dbUser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            var currentRoles = dbUser.Roles.Select(x => x.RoleId).ToList();

            var allRoles = _roleMange.Roles.ToList();

            EditUsersViewModel editUser = new EditUsersViewModel
            {
                Id = dbUser.Id,
                FullName = dbUser.FullName,
                Email = dbUser.Email,
                CreatedDate = dbUser.CreatedData,
            };


            foreach (var item in allRoles)
            {
                if(currentRoles.Contains(item.Id))

                {
                    editUser.Roles.Add(new CheckBoxItemViewModel
                    {
                        Id = item.Id,
                        Text =item.Name,
                        Checked=true,
                        
                    });
                }
                else
                {
                    editUser.Roles.Add(new CheckBoxItemViewModel
                    {
                        Id = item.Id,
                        Text =item.Name,
                        Checked=false,
                    });
                }
            }
            return editUser;

        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "FullName,Email,Password,ConfirmPassword,CreatedDate,CreatedTime")] InsertUserViewModel viewmodel, string[] roles)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    
                    UserName = viewmodel.FullName,
                    Email = viewmodel.Email,
                    CreatedData = DateTime.Now,
                    FullName = viewmodel.FullName,

                };
              

                var userAdded = UserManager.Create(user, viewmodel.Password);

                if (userAdded.Succeeded)
                {

                    if (roles !=null)
                    {
                        var requiredRoles = _roleMange.Roles.Where(x => roles.Contains(x.Id)).Select(x => x.Name).ToArray();
                        UserManager.AddToRoles(user.Id, requiredRoles);
                    }
                    return RedirectToAction(nameof(Index));
                }

            }

            InsertUserViewModel insertUser = new InsertUserViewModel();

            var roleFromd = _roleMange.Roles.ToList();
            List<CheckBoxItemViewModel> checkBoxListitem = new List<CheckBoxItemViewModel>();

            foreach (var item in roleFromd)
            {
                checkBoxListitem.Add(new CheckBoxItemViewModel
                {
                    Id = item.Id,
                    Text = item.Name,
                    Checked = false
                });

            }
          
            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = GetEditUsers(id);
            return View(user);
        }
    }
}