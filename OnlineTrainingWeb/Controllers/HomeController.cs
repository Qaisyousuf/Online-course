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
        public ActionResult Index()
        {
            return View(new HomePageViewModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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

            //List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            //foreach (var item in viewmodel)
            //{
            //    viewmodel.Add(new MenusViewModel
            //    {
            //        Id=item.Id,
            //        Title=item.Title,
            //        Description=item.Description,
            //        Url=item.Url,
            //        Parent=item.Parent,
            //        ParentId=item.ParentId,
            //    });
            //}

            context.Dispose();
            return PartialView(subMenus);
        }
    }
}