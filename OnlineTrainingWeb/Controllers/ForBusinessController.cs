using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class ForBusinessController : BaseController
    {
        [Route("Business")]
        public ActionResult Index(string slug)
        {

            var business = _uow.BusinessPageRepository.GetAll();

            List<BusinessPageViewModel> PageViewModel = new List<BusinessPageViewModel>();

            foreach (var item in business)
            {
                PageViewModel.Add(new BusinessPageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Slug=item.Slug,
                    Content=item.Content,
                    BusinessBanner=item.BusinessBanner,
                    BusinessBannerId=item.BusinessBannerId,
                    
                });
                ViewBag.PagetTitle = item.Title;
            }

            ListOfViewModels BusinessPageData = new ListOfViewModels
            {
                ListofBusinessPage=PageViewModel,
            };
            return View(BusinessPageData);
        }
    }
}