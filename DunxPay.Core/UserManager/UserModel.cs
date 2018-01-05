using System.Collections.Generic;

namespace DunxPay.Core.UserManager
{
    /// <summary>
    /// 用户登录信息实体类
    /// </summary>
    public class UserModel
    {
        public UserModel()
        {
            Permissions=new List<PermissionModel>();
            Roles=new List<string>();
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 真实名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 角色编码集合
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 用户类型[-1:超级管理员,0:一般管理员,1:一般用户]
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 用户可用权限集合
        /// </summary>
        public List<PermissionModel> Permissions { get; set; }
    }
}