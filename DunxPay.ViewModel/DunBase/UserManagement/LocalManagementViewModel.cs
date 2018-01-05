namespace DunxPay.ViewModel.DunBase.UserManagement
{
    public class LocalManagementViewModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobilenumber { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 状态[0:禁用,1:正常]
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 登录次数(累计)
        /// </summary>
        public int LoginCount { get; set; }
    }
}
