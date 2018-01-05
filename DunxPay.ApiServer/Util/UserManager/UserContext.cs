using DunxPay.ApiServer.Providers.Rbac;
using DunxPay.Core.CachingManager;
using DunxPay.Core.UserManager;
using DunxPay.Global;
using DunxPay.Global.Enums;
using DunxPay.Services.Inter.DunBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DunxPay.ApiServer.Util.UserManager
{
    /// <summary>
    /// 用户上下文信息实体类
    /// </summary>
    public static class UserContext
    {
        private static readonly object _lock = new object();
        /// <summary>
        /// 用户ID
        /// </summary>
        public static int Id { get { return User.Id; } }
        /// <summary>
        /// 登录名
        /// </summary>
        public static string LoginName { get { return User.LoginName; } }
        /// <summary>
        /// 真实名
        /// </summary>
        public static string RealName { get { return User.RealName; } }
        /// <summary>
        /// 部门
        /// </summary>
        public static string Department { get { return User.Department; } }
        /// <summary>
        /// 角色编码集合
        /// </summary>
        public static List<string> Roles { get { return User.Roles; } }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public static bool IsSuperAdmin
        {
            get
            {
                return User.Type == (int)UserType.SuperAdministrator && IsLogin;
            }
        }

        /// <summary>
        /// 当前用户是否已登录
        /// </summary>
        public static bool IsLogin
        {
            get { return Id > 0; }
        }

        /// <summary>
        /// 用户可用权限集合
        /// </summary>
        public static List<PermissionModel> Permissions
        {
            get { return User.Permissions; }
        }

        /// <summary>
        /// 用户信息实体类
        /// </summary>
        public static UserModel User
        {
            get
            {
                object tmp;
                var success = Cache.Global.TryGet(UserCacheKey, out tmp);
                if (success)
                {
                    return tmp as UserModel;
                }
                var userModel = FindUserAndPermissions();
                SetLogin(userModel);
                return userModel;
            }
        }

        /// <summary>
        /// 获取凭证客户端平台ID
        /// </summary>
        public static string ClaimsClient
        {
            get
            {
                try
                {
                    var clientId = ClaimsPrincipal.FindFirst("aud").Value;
                    return clientId;
                }
                catch (Exception e)
                {
                    return "-1";
                }

            }
        }

        /// <summary>
        /// 获取凭证主体
        /// </summary>
        private static ClaimsPrincipal ClaimsPrincipal
        {
            get
            {
                var principal = HttpContext.Current.User as ClaimsPrincipal;

                return principal;
            }
        }

        /// <summary>
        /// 获取用户登录名
        /// </summary>
        private static string UserName
        {
            get
            {
                var identity = ClaimsPrincipal.Identity;
                var userName = identity.Name;
                return userName;
            }
        }

        /// <summary>
        /// 获取用户缓存键
        /// </summary>
        private static string UserCacheKey
        {
            get
            {
                return string.Format(PlatformUserCacheKey.CacheKeyUserModel, ClaimsClient, UserName);
            }
        }

        /// <summary>
        /// 查询用户及用户拥有的权限集合
        /// </summary>
        /// <returns></returns>
        private static UserModel FindUserAndPermissions()
        {
            lock (_lock)
            {
                //var userService = _container.Resolve<IJmpLocuserService>();
                var userProvider = UserProviderDictionary.GetUserProvider(ClaimsClient.Trim().ToLower());
                var userModel = userProvider.FindByLoginName(UserName, ClaimsClient);
                var isSuperAdmin = userModel.Type == (int)UserType.SuperAdministrator && userModel.Id > 0;
                var rbacService = DependencyResolver.Current.GetService<IRbacService>();
                var permissions = rbacService.FindPermissions(userModel.Id, isSuperAdmin);
                userModel.Permissions = permissions.Select(x => new PermissionModel
                {
                    ActionCode = x.ActionCode,
                    ActionName = x.ActionName,
                    ModuleCode = x.ModuleCode,
                    ModuleName = x.ModuleName,
                    PlatformId = x.ClientId,
                    RequestUrl = x.RequestUrl,
                    IsButton = x.IsButton,
                    ButtonType = x.ButtonType,
                    JsOperatingFunction = x.JsOperatingFunction,
                    ButtonIcon = x.ButtonIcon
                }).ToList();
                return userModel;
            }
        }

        /// <summary>
        /// 获取指定页面的所有权限集合
        /// </summary>
        /// <param name="requestUrl">请求页面</param>
        /// <returns></returns>
        public static List<PermissionModel> FindPermissionsByRequestUrl(string requestUrl)
        {
            requestUrl = requestUrl.Trim();
            return User.Permissions.FindAll(x => string.Equals(x.RequestUrl.Trim('/').Trim(), requestUrl, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// 用户登录方法[登录时调用]
        /// </summary>
        /// <param name="userModel">用户登录信息实体</param>
        public static void SetLogin(UserModel userModel)
        {
            Cache.Global.AddOrUpdate(UserCacheKey, userModel);
        }
    }
}

