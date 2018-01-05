using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.Domain.QueryModel.Admin.User
{
   public  class RolePermissionQueryModel
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleIdentifyCode { get; set; }

        /// <summary>
        /// 操作码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 权限标识码
        /// </summary>
        public string IdentifyCode { get; set; }
    }
}
