using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.LogCenter.EnumHelper
{
    public enum LogType
    {
        /// <summary>
        /// 新增
        /// </summary>
        Create = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Modify = 2,
        /// <summary>
        /// 操作
        /// </summary>
        Operate = 3,
        /// <summary>
        /// 登录
        /// </summary>
        Login = 4,
        /// <summary>
        /// 访问
        /// </summary>
        Visit = 5
    }
}
