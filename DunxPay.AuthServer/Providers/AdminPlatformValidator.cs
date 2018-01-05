using Autofac;
using DunxPay.AuthServer.Extensions;
using DunxPay.AuthServer.Models.Util;
using DunxPay.Core.UserManager;
using DunxPay.Mapping;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.AuthServer.Providers
{
    /// <summary>
    /// 运营平台用户验证器
    /// </summary>
    public class AdminPlatformValidator : PlatformValidator
    {
        /// <summary>
        /// 验证平台用户信息是否有效
        /// </summary>
        /// <param name="scope">依赖注册的作用域</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="clientId">平台ID</param>
        /// <param name="userModel">用户信息实体对象</param>
        /// <returns></returns>
        public override ValidateResponseModel Validate(ILifetimeScope scope, string userName, string password, string clientId, out UserModel userModel)
        {
            var response = ValidateResponseModelFactory.Instance;
            var userService = scope.Resolve<IJmpLocuserService>();
            userModel = new UserModel();

            var user = userService.FindByLoginName(userName.Trim());
            if (user == null)
            {
                response.Invalid("登录名错误");
                return response;
            }

            //将领域模型转换成视图模型
            var tmp = user.ToModel();
            //用户登录验证
            var userValidator = tmp.LoginValidator(password, clientId);
            if (userValidator.IsValid)
            {
                userModel.LoginName = tmp.LoginName;
                userModel.ClientId = clientId;
                userModel.Id = tmp.Id;
                userModel.Type = tmp.Type;
                response.IsValid = true;
                return response;
            }
            response.Invalid(userValidator.Message);
            return response;
        }
    }
}