using Autofac.Integration.Owin;
using DunxPay.Core.UserManager;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DunxPay.AuthServer.Providers
{
    /// <summary>
    /// 自定义OAuth提供者
    /// </summary>
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 重写客户端验证授权方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set.");
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            Thread.Sleep(1500);

            var scope = context.OwinContext.GetAutofacLifetimeScope();

            #region original method
            //var userService = scope.Resolve<IJmpLocuserService>();

            //var user = userService.FindByLoginName(context.UserName.Trim());
            //if (user == null)
            //{
            //    context.SetError("无效的请求", "登录名错误");
            //    return Task.FromResult<object>(null);
            //}
            ////将领域模型转换成视图模型
            //var userModel = user.ToModel();
            ////用户登录验证
            //var userValidator = userModel.LoginValidator(context.Password, context.ClientId);
            //if (!userValidator.IsValid)
            //{
            //    context.SetError("无效的请求", userValidator.Message);
            //    return Task.FromResult<object>(null);
            //} 
            #endregion

            UserModel userModel;
            var platformValidator = PlatformValidatorDictionary.GetPlatformValidator(context.ClientId.Trim().ToLower());
            var validateResponse = platformValidator.Validate(scope, context.UserName.Trim(), context.Password.Trim(), context.ClientId.Trim(), out userModel);

            if (!validateResponse.IsValid)
            {
                context.SetError("无效的请求", validateResponse.Messages.FirstOrDefault());
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userModel.LoginName));
            //admin id
            identity.AddClaim(new Claim("adm_id", userModel.Id.ToString()));
            identity.AddClaim(new Claim("adm_typ", userModel.Type.ToString()));
            var props = new AuthenticationProperties(
                new Dictionary<string, string>
                {
                    {"audience", context.ClientId ?? string.Empty},
                    { "secret_key","IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"},
                    { "issuer","dunxingpay"}
                });

            var ticket = new AuthenticationTicket(identity, props);

            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }

        #region Overrides of OAuthAuthorizationServerProvider

        /// <summary>
        /// Called at the final stage of a successful Token endpoint request. An application may implement this call in order to do any final
        /// modification of the claims being used to issue access or refresh tokens. This call may also be used in order to add additional
        /// response parameters to the Token endpoint's json response body.
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>Task to enable asynchronous execution</returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                if (property.Key == "secret_key")
                {
                    continue;
                }
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            var tokenExpireHours = 12;
            try
            {
                tokenExpireHours = Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpireHours"]);
            }
            catch
            {
            }
            var accessExpiration = DateTimeOffset.Now.AddHours(tokenExpireHours);
            context.Properties.ExpiresUtc = accessExpiration;
            return Task.FromResult<object>(null);
        }

        #endregion
    }
}