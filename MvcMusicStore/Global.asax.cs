using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcMusicStore.Helpers;

namespace MvcMusicStore
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default_0", // 路由名称
                "Index.aspx", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

            routes.MapRoute(
                "Default_1", // 路由名称
                "{controller}/{action}.aspx", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}.aspx", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            //disable compression (if enabled). More info - http://stackoverflow.com/questions/3960707/asp-net-mvc-weird-characters-in-error-page
            CompressAttribute.DisableCompression(HttpContext.Current);
            //log error
            //LogException(Server.GetLastError());
        }
    }
}