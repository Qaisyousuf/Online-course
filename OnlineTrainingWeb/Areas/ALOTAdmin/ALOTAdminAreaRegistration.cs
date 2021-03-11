using System.Web.Mvc;

namespace OnlineTrainingWeb.Areas.ALOTAdmin
{
    public class ALOTAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ALOTAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ALOTAdmin_default",
                "ALOTAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}