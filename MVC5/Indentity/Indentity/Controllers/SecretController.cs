using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indentity.Controllers
{

    [Authorize(Users ="errol@bubbanoosh.com.au")]
    public class SecretController : Controller
    {
        // GET: Secret
        
        public ContentResult Secret()
        {
            return Content("This is a secret!");
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("Not a secret...");
        }
    }
}