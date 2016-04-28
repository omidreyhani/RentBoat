using System.Web.Mvc;

namespace RentBoat.WebSite.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customer_default",
                "{controller}/{action}/{id}",
                           new { controller = "Boat", action = "Index", id = UrlParameter.Optional }, new[] { "RentBoat.WebSite.Areas.Customer.Controllers" }
            );
        }
    }
}