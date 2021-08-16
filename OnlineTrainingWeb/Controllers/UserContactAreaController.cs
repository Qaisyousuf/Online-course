using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Data;
using Microsoft.AspNet.Identity.Owin;

namespace OnlineTrainingWeb.Controllers
{
    public class UserContactAreaController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleMange = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

       
        // GET: UserContactArea
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        [Route("UserContact")]
        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                ModelState.AddModelError("", "Please login first");
            }

            return View(new UserContactViewModel());
        }

        [HttpPost]
        [Route("UserContact")]
        public ActionResult Create(UserContactViewModel viewmodel)
        {
            if (ModelState.IsValid && Request.IsAuthenticated && User.Identity.IsAuthenticated)
            {
                var CurrentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var currentEmail = UserManager.GetEmail(CurrentUser);


                var currentFullName = System.Web.HttpContext.Current.User.Identity.Name;
                var userContact = new UserContact
                {

                    Id = viewmodel.Id,
                    Message = viewmodel.Message,
                    ContactEmail = currentEmail.ToString(),
                    ContactBy = currentFullName.ToString(),
                    Name = viewmodel.Name,
                    ApplicationUsers = viewmodel.ApplicationUsers,
                    UserId = CurrentUser,

                };

                _uow.UserContactRepository.Add(userContact);
                _uow.Commit();

                return Json(new { success = true, message = "Thank You! " + userContact.Name + " for contacting us" }, JsonRequestBehavior.AllowGet);
            }

            return View(viewmodel);
        }

        //[HttpGet]
        //[Route("UserContact")]
        //public ActionResult GetUserPostData()
        //{
        //    var userData = _uow.UserContactRepository.GetAll();

        //    List<UserContactViewModel> viewmodel = new List<UserContactViewModel>();

        //    foreach (var item in userData)
        //    {
        //        viewmodel.Add(new UserContactViewModel
        //        {
        //            Id = item.Id,
        //            Message = item.Message,
        //            Name = item.Name,
        //        });
        //    }

        //    ListOfViewModels UserContactData = new ListOfViewModels
        //    {
        //        ListOfUserContact = viewmodel,
        //    };
        //    return View(UserContactData);
        //}
    }
}