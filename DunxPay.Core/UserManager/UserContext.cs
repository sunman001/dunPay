using DunxPay.Global.Enums;
using System.Collections.Generic;
using System.Web;

namespace DunxPay.Core.UserManager
{
    /// <summary>
    /// 用户上下文信息实体类
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// 用户信息Session键
        /// </summary>
        public static readonly string SessionKey = "user_model";
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
        private static UserModel User
        {
            get
            {
                return HttpContext.Current.Session[SessionKey] == null
                    ? new UserModel()
                    : HttpContext.Current.Session[SessionKey] as UserModel;
            }
        }

        /// <summary>
        /// 用户登录方法[登录时调用]
        /// </summary>
        /// <param name="userModel">用户登录信息实体</param>
        public static void SetLogin(UserModel userModel)
        {
            HttpContext.Current.Session[SessionKey] = userModel;
        }

        /// <summary>
        /// 用户注销方法[注销时调用]
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session[SessionKey] = null;
            HttpContext.Current.Session.Clear();
        }
    }
}
