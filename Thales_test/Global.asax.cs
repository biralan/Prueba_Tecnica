using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Thales_test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public static class GLOBALES
        {
            public static String PROTOCOLO { get { return HttpContext.Current.Request.Url.Scheme; } }
            public static String HOST { get { return HttpContext.Current.Request.Url.Host; } }
            public static String PUERTO { get { return (HttpContext.Current.Request.Url.Port == 80 || HttpContext.Current.Request.Url.Port == 443) ? String.Empty : ":" + HttpContext.Current.Request.Url.Port.ToString(); } }
            public static String VISTA { get { return HttpContext.Current.Request.Url.AbsolutePath; } }
            public static String SITIO { get { return PROTOCOLO + "://" + HOST + PUERTO + "/"; } }
            public static String API { get { return PROTOCOLO + "://" + HOST + PUERTO + "/" + "api/"; } }


        }
        public static class _Json
        {
            public static JsonResult Result(Object Res)
            {
                JsonResult r = new JsonResult
                {
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = Res
                };
                return r;
            }
        }
    }
}
