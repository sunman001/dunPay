using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Routing;

namespace DunxPay.AuthServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //UnityConfig.RegisterComponents();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            JsonResposeFormatter();
        }

        private static void JsonResposeFormatter()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Set("Server", "Apache");
        }
    }
}
