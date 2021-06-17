using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "home";
            if(!_uow.HomePageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page not found";
                return RedirectToAction(nameof(Index), new { slug="" });
            }

            HomePageViewModel viewmodel;
            HomePage pagefromDb;
            pagefromDb = _uow.HomePageRepository.GetHomePageBySlug(slug);
            ViewBag.PageTitle = pagefromDb.Title;

            TempData["HomeBanner"] = pagefromDb.HomeBannerId;
            TempData["ExplorationBanner"] = pagefromDb.HomeExplorationBannerId;

            viewmodel = new HomePageViewModel
            {
                Id=pagefromDb.Id,
                Title=pagefromDb.Title,
                Content=pagefromDb.Content,


            };
          
            return View(viewmodel);
        }

         [HttpGet]
         [ChildActionOnly]
         public ActionResult GetHomeBanner()
        {
            int id = (int)TempData["HomeBanner"];
            var homebanner = _uow.HomeBannerRepository.GetById(id);

            HomeBannerViewModel viewmodel = new HomeBannerViewModel
            {
                Id=homebanner.Id,
                MainTitle=homebanner.MainTitle,
                SubTitle=homebanner.SubTitle,
                ImageUrl=homebanner.ImageUrl,
                JoinButton=homebanner.JoinButton,
                JoinButtonUrl=homebanner.JoinButtonUrl,
                DiscoverButton=homebanner.DiscoverButton,
                DiscoverButtonUrl=homebanner.DiscoverButton,
                Content=homebanner.Content,
                SubMaintitle=homebanner.SubMaintitle,
            };

            return PartialView(viewmodel);
        }

        [ChildActionOnly]
        public ActionResult PartialMenus()
        {
           
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var menu in menus)
            {
                context.Entry(menu).Collection(s => s.SubMenus).Query().Where(x => x.ParentId == menu.Id);
            }
            var subMenus = menus.AsNoTracking().ToList();

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            //foreach (var item in viewmodel)
            //{
            //    viewmodel.Add(new MenusViewModel
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Description = item.Description,
            //        Url = item.Url,
            //        Parent = item.Parent,
            //        ParentId = item.ParentId,
            //    });
            //}

            context.Dispose();
            return PartialView(subMenus);
        }
    }
}