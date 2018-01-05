using Autofac;
using DunxPay.AuthServer.Models.Util;
using DunxPay.Core.UserManager;

namespace DunxPay.AuthServer.Providers
{
    /// <summary>
    /// 平台用户信息验证基类
    /// </summary>
    public abstract class PlatformValidator
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
        public abstract ValidateResponseModel Validate(ILifetimeScope scope, string userName, string password, string clientId,
            out UserModel userModel);
    }
}