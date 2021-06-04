using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;

namespace OnlineTrainingWeb.Areas.ALOTAdmin.Controllers
{
    public class SearchBoxImplementationController : Controller
    {
        private readonly IUnitOfWork uow;

        public SearchBoxImplementationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetSearchItem(string prefix)
        {
            var search = uow.Context.MenuSearchBoxes.Where(x => x.Name.Contains(prefix)).Select(p => p.Url).ToList();


            return Json(search, JsonRequestBehavior.AllowGet);
           

        }
    }
}