using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainingWeb.Controllers
{
    public class CoursesDescriptionController : BaseController
    {
        [Route("CoursesDescription")]
        public ActionResult Index()
        {
            return View();
        }
    }
}