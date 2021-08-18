using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using ViewModel;
namespace OnlineTrainingWeb.Controllers
{
    [HandleError]
    public class SubscriptionFooterController : BaseController
    {
        // GET: SubscriptionFooter
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("mvc-5-training")]
        public ActionResult Create()
        {
            return View(new SubscriptionSystemViewModel());
        }
    }
}