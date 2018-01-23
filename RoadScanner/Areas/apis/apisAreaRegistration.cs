using System.Web.Mvc;

namespace RoadScanner.Areas.apis
{
    public class apisAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "apis";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "apis_default",
                "apis/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}