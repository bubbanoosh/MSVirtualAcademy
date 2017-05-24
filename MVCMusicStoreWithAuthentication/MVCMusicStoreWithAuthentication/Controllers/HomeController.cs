using MVCMusicStoreWithAuthentication.AuthData;
using System.Web.Mvc;


namespace MVCMusicStoreWithAuthentication.Controllers
{
    public class HomeController : Controller
    {

        //[AuthAttribute]
        //[AuthorizeAttribute]
        //[Authorize()]
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 10)]
        public ActionResult About()
        {
            ViewBag.Message = "This is the application description page ViewBag.Message Contents.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}