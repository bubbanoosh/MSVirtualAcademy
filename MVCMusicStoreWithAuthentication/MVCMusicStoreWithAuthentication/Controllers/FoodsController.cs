using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreWithAuthentication.Controllers
{
    public class FoodsController : Controller
    {
        // GET: Foods
        public ActionResult Search(string name)
        {

            
            return Content("Food here is: " + Server.HtmlEncode(name));
        }
    }
}