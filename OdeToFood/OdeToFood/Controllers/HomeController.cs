using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string q = null)
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        OdeToFoodDB _db = new OdeToFoodDB();
    }
}
