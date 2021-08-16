using Data.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class UserContactController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserContactController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: ALOTAdmin/UserContact
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserContactData()
        {
            var userContact = uow.UserContactRepository.GetAll();

            List<UserContactViewModel> viewmodel = new List<UserContactViewModel>();

            foreach (var item in userContact)
            {
                viewmodel.Add(new UserContactViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Message = item.Message,
                    ContactEmail = item.ContactEmail,
                    ContactBy = item.ContactBy,
                    ApplicationUsers = item.ApplicationUsers,
                    UserId = item.UserId,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userContact = uow.UserContactRepository.GetById(id);

            UserContactViewModel viewmodel = new UserContactViewModel
            {
                Id=userContact.Id,
                Name=userContact.Name,
                Message=userContact.Message,
                ContactBy=userContact.ContactBy,
                ContactEmail=userContact.ContactEmail,
                ApplicationUsers=userContact.ApplicationUsers,
                UserId=userContact.UserId,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserContactViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userContact = uow.UserContactRepository.GetById(viewmodel.Id);

                userContact.Id = viewmodel.Id;
                userContact.Name = viewmodel.Name;
                userContact.Message = viewmodel.Message;
                userContact.ContactBy = viewmodel.ContactBy;
                userContact.ContactEmail = viewmodel.ContactEmail;
                userContact.ApplicationUsers = viewmodel.ApplicationUsers;
                userContact.UserId = viewmodel.UserId;

                uow.UserContactRepository.Update(userContact);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userContact = uow.UserContactRepository.GetById(id);

            UserContactViewModel viewmodel = new UserContactViewModel
            {
                Id = userContact.Id,
                Name=userContact.Name,
                Message = userContact.Message,
                ContactBy = userContact.ContactBy,
                ContactEmail = userContact.ContactEmail,
                ApplicationUsers = userContact.ApplicationUsers,
                UserId=userContact.UserId,
            };

            return View(viewmodel);
        }

    }
}