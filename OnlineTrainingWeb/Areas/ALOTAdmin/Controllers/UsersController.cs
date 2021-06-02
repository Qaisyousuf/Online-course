using System;
using System.Collections.Generic;
using System.Data.Entity;
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

      
        

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        private DeleteUserViewModelcs GetDeleteData(string id)
        {
            var dbUser = UserManager.Users.Include(u => u.Roles).Where(x => x.Id == id).FirstOrDefault();

            var curretnRolesForDelete = dbUser.Roles.Select(x => x.RoleId).ToList();

            var allRolesForDelete = _roleMange.Roles.ToList();

            DeleteUserViewModelcs deleteUser = new DeleteUserViewModelcs();

            deleteUser.FullName = dbUser.FullName;
            deleteUser.Email = dbUser.Email;
            deleteUser.CreatedDate = dbUser.CreatedData;

            foreach (var role in allRolesForDelete)
            {
                if (curretnRolesForDelete.Contains(role.Id))
                {
                    deleteUser.Roles.Add(new CheckBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = true });
                }
                else
                {
                    deleteUser.Roles.Add(new CheckBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = false });
                }
            }

            return deleteUser;
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var deleteUsers = GetDeleteData(id);
            return View(deleteUsers);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            var userFromDb = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            var userDeleteed = UserManager.Delete(userFromDb);

            return RedirectToAction(nameof(Index));
        }
        private EditUsersViewModel GetEditUser(string id)
        {
            var dbUser = UserManager.Users.Include(u => u.Roles).Where(x => x.Id == id).FirstOrDefault();

            // we fetch all the roleids for the above user

            var currentUserRoles = dbUser.Roles.Select(x => x.RoleId).ToList();

            // we fetch all the roles from the roles table

            var allRoles = _roleMange.Roles.ToList();

            EditUsersViewModel editUser = new EditUsersViewModel();

            editUser.Id = dbUser.Id;
            editUser.FullName = dbUser.UserName;
            editUser.Email = dbUser.Email;
            editUser.CreatedDate = dbUser.CreatedData;
           

            foreach (var role in allRoles)
            {
                if (currentUserRoles.Contains(role.Id))
                {
                    editUser.Roles.Add(new CheckBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = true });
                }
                else
                {
                    editUser.Roles.Add(new CheckBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = false });
                }
            }

            return editUser;

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = GetEditUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Password,ConfirmPassword,CreatedDate")] EditUsersViewModel viewmodel, string[] Roles)
        {
            if (ModelState.IsValid)
            {
                var dbuser = UserManager.Users.Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                if (dbuser != null)
                {
                    string[] currentRoles = dbuser.Roles.Select(x => x.RoleId).ToArray();

                    string[] roleNmae = _roleMange.Roles.Where(x => currentRoles.Contains(x.Id)).Select(x => x.Name).ToArray();

                    UserManager.RemoveFromRoles(dbuser.Id, roleNmae);

                    dbuser.UserName = viewmodel.FullName;
                    dbuser.Email = viewmodel.Email;
                    dbuser.CreatedData = DateTime.Now;

                    UserManager.Update(dbuser);

                    if (Roles != null)
                    {
                        var requiredRoles = _roleMange.Roles.Where(x => Roles.Contains(x.Id)).Select(x => x.Name).ToArray();

                        UserManager.AddToRoles(dbuser.Id, requiredRoles);
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return HttpNotFound();
                }

            }
            else
            {
                var editUser = GetEditUser(viewmodel.Id);
                viewmodel.Roles = editUser.Roles;

                return View(viewmodel);
            }
        }
    }
}