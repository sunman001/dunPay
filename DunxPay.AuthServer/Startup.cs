using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.WebApi;
using DunxPay.AuthServer.Common.ExecptionHandler;
using DunxPay.AuthServer.Formats;
using DunxPay.AuthServer.Providers;
using DunxPay.Global;
using DunxPay.Mapping;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace DunxPay.AuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            var assembly = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assembly)
                .Where(
                    t => t.GetInterfaces()
                        .Any(i => i.IsAssignableFrom(typeof(IDependency)))
                )
                .AsImplementedInterfaces()
                .InstancePerDependency();

            /*
            builder.RegisterType<CustomOAuthProvider>()
                .As<IOAuthAuthorizationServerProvider>()
                .PropertiesAutowired()
                .SingleInstance();
            */

            //builder.Register(x=>new TestManager("userService")).PropertiesAutowired();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler());
            //config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            app.UseOwinExceptionHandler();
            app.UseAutofacMiddleware(container);
            app.UseCors(CorsOptions.AllowAll);
            ConfigureOAuth(app, container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            WebApiConfig.Register(config);

            RegisterAutoMapper();

            //Init application data
            InitApplicationData();
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                //AccessTokenExpireTimeSpan = TimeSpan.FromHours(12),
                Provider = new CustomOAuthProvider(),
                //container.Resolve<IOAuthAuthorizationServerProvider>(), //
                //AuthorizationCodeExpireTimeSpan = TimeSpan.FromHours(8),
                AccessTokenFormat = new CustomJwtFormat()
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);

        }

        /// <summary>
        /// 注册AutoMapper的配置
        /// </summary>
        private void RegisterAutoMapper()
        {
            new AutoMapperStartupTask().Execute();
        }

        /// <summary>
        /// 初始化应用程序的数据
        /// </summary>
        private void InitApplicationData()
        {
            PlatformValidatorDictionary.Init();
        }
    }
}