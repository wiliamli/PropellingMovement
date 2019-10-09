using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MessageReceiveClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.IgnoreRoute("signalr", "signalr/{*pathInfo}");

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
