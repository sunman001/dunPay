using System.ComponentModel;

namespace DunxPay.Global.Enums
{
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        SuperAdministrator = -1,
        /// <summary>
        /// 一般管理员
        /// </summary>
        [Description("一般管理员")]
        Administrator = 0,
        /// <summary>
        /// 一般用户
        /// </summary>
        [Description("一般用户")]
        GeneralUser = 1
    }
}
