using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TFSWebHook
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API 配置和服务
			//ExceptionlessClient.Default.RegisterWebApi(config);

			// Web API 路由
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// Initialize Vsts WebHook receiver
			config.InitializeReceiveVstsWebHooks();
		}
	}
}
