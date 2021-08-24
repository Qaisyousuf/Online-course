using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Models;

namespace OnlineTrainingWeb.Controllers
{
    public class UserClassDataController : BaseController
    {
        [Route("UserClassData")]
        public ActionResult Index()
        {
            var userClassData = _uow.ClassDataRepository.GetAll("ApplicationUsers");
            List<ClassDataViewModel> viewmodel = new List<ClassDataViewModel>();

            foreach (var item in userClassData)
            {
                viewmodel.Add(new ClassDataViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ClassName=item.ClassName,
                    ClassStartData=item.ClassStartData,
                    ClassStartTime=item.ClassStartData,
                    TotalCourseDays=item.TotalCourseDays,
                    ClassDescription=item.ClassDescription,
                    ContactedBy=item.ClassDescription,
                    UserName=item.UserName,
                    UserId=item.UserId,
                    ApplicationUsers=item.ApplicationUsers,
                });
            }
            return View(viewmodel);
        }

      
    }
}