using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class UserContactPostController : BaseController
    {
        [Route("UserContactPost")]
        public ActionResult Index()
        {
            var userData = _uow.UserContactRepository.GetAll("ApplicationUsers");

            

            List<UserContactViewModel> viewmodel = new List<UserContactViewModel>();

            foreach (var item in userData)
            {
                viewmodel.Add(new UserContactViewModel
                {
                    Id = item.Id,
                    Message = item.Message,
                    Name = item.Name,
                    ContactEmail = item.ContactEmail,
                    ContactBy = item.ContactBy,
                    ApplicationUsers=item.ApplicationUsers,
                    UserId=item.UserId,
                });
            }

            return View(viewmodel);
                /*Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);*/
        }
        //[HttpGet]
        //[Route("UserContactPost")]
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
        //            ContactEmail=item.ContactEmail,
        //            ContactBy=item.ContactBy,
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