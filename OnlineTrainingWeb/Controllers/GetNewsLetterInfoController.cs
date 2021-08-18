using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace OnlineTrainingWeb.Controllers
{
    [HandleError]
    public class GetNewsLetterInfoController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        [Route("GetNewsLetter")]
        public ActionResult GetNewsLetterContact()
        {
            return View(new SubscriptionSystemViewModel());
        }
    }
}