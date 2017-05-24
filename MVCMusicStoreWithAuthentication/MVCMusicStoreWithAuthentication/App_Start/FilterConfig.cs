using MVCMusicStoreWithAuthentication.App_Code;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreWithAuthentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //filters.Add(new CustomRequireHttpsFilter());
        }
    }


    //[Log]
    /// <summary>
    /// Usage = [Log]
    ///         public ActionResult SomeAction()
    ///         {
    ///             ...
    ///         }
    /// </summary>
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}
