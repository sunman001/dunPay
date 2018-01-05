using DunxPay.Core.UserManager;

namespace DunxPay.ApiServer.Providers.Rbac
{
    /// <summary>
    /// 用户信息提供基类
    /// </summary>
    public abstract class UserProvider
    {
        /// <summary>
        /// 平台ID
        /// </summary>
        public abstract string ClientId { get; protected set; }

        /// <summary>
        /// 根据用户查询用户信息实体
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="clientId">平台ID</param>
        /// <returns></returns>
        public abstract UserModel FindByLoginName(string loginName, string clientId);
    }
}