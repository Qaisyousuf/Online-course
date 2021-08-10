using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class DashboardAreaController : BaseController
    {
        [Route("Dashboard")]
        public ActionResult Index(string slug)
        {
            var dashboar = _uow.DashboardUserRepository.GetAll();
            List<DashboardUsersViewModel> viewmodel = new List<DashboardUsersViewModel>();

            foreach (var item in dashboar)
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

            ListOfViewModels DashboardData = new ListOfViewModels
            {
                ListofDashboard=viewmodel,
            };
            return View(DashboardData);
        }


    }
}