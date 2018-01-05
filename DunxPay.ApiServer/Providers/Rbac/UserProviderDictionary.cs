using DunxPay.Global.Enums;
using System;
using System.Collections.Generic;

namespace DunxPay.ApiServer.Providers.Rbac
{
    /// <summary>
    /// 平台用户信息提供者字典
    /// </summary>
    public class UserProviderDictionary
    {
        /// <summary>
        /// 平台用户信息提供者字典
        /// </summary>
        private static readonly Dictionary<string, UserProvider> UserProviders = new Dictionary<string, UserProvider>();

        /// <summary>
        /// 向字典中添加新的平台用户信息提供者
        /// </summary>
        /// <param name="clientId">平台ID</param>
        /// <param name="userProvider">用户数据提供者对象</param>
        public static void Add(string clientId, UserProvider userProvider)
        {
            if (!UserProviders.ContainsKey(clientId))
            {
                UserProviders.Add(clientId, userProvider);
            }
        }

        /// <summary>
        /// 初始化平台用户信息提供者字典
        /// </summary>
        public static void Init()
        {
            UserProviders.Add(((int)DxClient.Administrator).ToString(), new AdminUserProvider());
        }

        /// <summary>
        /// 获取所有实现了的平台用户信息提供者实体对象集合
        /// </summary>
        public static Dictionary<string, UserProvider> GetUserProviders
        {
            get
            {
                return UserProviders;
            }
        }

        /// <summary>
        /// 根据平台ID获取平台用户信息提供者实体对象
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public static UserProvider GetUserProvider(string clientId)
        {
            if (UserProviders.ContainsKey(clientId))
            {
                return UserProviders[clientId];
            }
            throw new NotSupportedException("平台用户信息提供者组件未注册");
        }
    }
}