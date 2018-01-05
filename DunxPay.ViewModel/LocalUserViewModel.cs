namespace DunxPay.ViewModel
{
    public class LocalUserViewModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 加密过的密码串
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 状态[0:禁用,1:正常]
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 用户类型[-1:超级管理员,0:一般管理员,1:一般用户],默认值:1
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 登录次数(累计)
        /// </summary>
        public int LoginCount { get; set; }
    }
}
