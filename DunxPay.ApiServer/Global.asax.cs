using DunxPay.Mapping;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DunxPay.ApiServer
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterAutoMapperTask();
        }

        /// <summary>
        /// Register AutoMapper task
        /// </summary>
        private void RegisterAutoMapperTask()
        {
            new AutoMapperStartupTask().Execute();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //var context = HttpContext.Current;
            //var response = context.Response;

            //response.AddHeader("Access-Control-Allow-Origin", "*");
            //response.AddHeader("X-Frame-Options", "ALLOW-FROM *");

            //if (context.Request.HttpMethod == "OPTIONS")
            //{
            //    response.AddHeader("Access-Control-Allow-Methods", "GET, POST, DELETE, PATCH, PUT");
            //    response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //    response.AddHeader("Access-Control-Max-Age", "1000000");
            //    response.End();
            //}
        }
    }
}
