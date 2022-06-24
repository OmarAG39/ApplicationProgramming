using Microsoft.AspNetCore.Mvc;

namespace BP.API.Web.Controllers
{
    public class HomeController : CorporateControllerBase
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");            
        }

        public ActionResult About()
        {
            return View();
        }
    }
}