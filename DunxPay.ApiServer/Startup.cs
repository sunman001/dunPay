using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DunxPay.ApiServer.Common.Routing;
using DunxPay.ApiServer.Providers.Rbac;
using DunxPay.ApiServer.Util.LogWriter;
using DunxPay.Global;
using DunxPay.Mapping;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(DunxPay.ApiServer.Startup))]

namespace DunxPay.ApiServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region Autofac
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterAssemblyTypes(typeof(IDependency).Assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            var assembly = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assembly)
                .Where(
                    t => t.GetInterfaces()
                          .Any(i => i.IsAssignableFrom(typeof(IDependency)))
                 )
                .AsImplementedInterfaces()
                .InstancePerDependency();

            //注册运管平台日志工厂
            builder.RegisterType<AdminLogFactory>().As<IAdminLogFactory>();

            builder.RegisterFilterProvider();
            builder.RegisterType<PermissionFilterAttribute>().PropertiesAutowired();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            app.UseAutofacMiddleware(container);

            ConfigureOAuth(app);
            app.UseAutofacWebApi(config);

            //var httpServer = new HttpServer(config);
            //config.AddApiVersioning(o =>
            //    {
            //        o.ReportApiVersions = true;
            //        o.AssumeDefaultVersionWhenUnspecified = true;
            //        o.DefaultApiVersion = new ApiVersion(1, 0);
            //        o.ApiVersionReader = new HeaderApiVersionReader("api-version");
            //        o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
            //    }
            //);
            //config.MapHttpAttributeRoutes();
            //config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector1(config));


            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);
            config.Services.Replace(typeof(IHttpControllerSelector),new NamespaceHttpControllerSelector(config));
            //config.Services.Replace(typeof(IExceptionFilter) ,new ApiExceptionAttribute());
            //config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler()); 
            config.Filters.Add(new ApiExceptionAttribute());

            app.UseWebApi(config);
            

            //container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            WebApiConfig.Register(config);
            RegisterAutoMapper();
            #endregion
            
            UserProviderDictionary.Init();
        }

        private void RegisterAutoMapper()
        {
            new AutoMapperStartupTask().Execute();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["Issuer"].Trim();
            var audience = ConfigurationManager.AppSettings["ClientId"].Trim().Split(',');
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["SecretKey"].Trim());

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = audience,
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            //context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("newCustomClaim", "newValue"));
                            return Task.FromResult<object>(null);
                        },
                        OnRequestToken = context =>
                        {
                            var token = context.Token;
                            return Task.FromResult<object>(null);
                        }
                    }
                });

        }
    }
}
