using System.Web.Mvc;

namespace RoadScanner.Areas.Anomaly
{
    public class AnomalyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Anomaly";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Anomaly_default",
                "Anomaly/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}