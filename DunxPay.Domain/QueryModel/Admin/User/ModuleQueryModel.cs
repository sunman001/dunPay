using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.Domain.QueryModel.Admin.User
{
  public   class ModuleQueryModel
    {
       
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标识码
        /// </summary>
        public string IdentifyCode { get; set; }
        /// <summary>
        /// 父级标识码
        /// </summary>
        public string ParentIdentifyCode { get; set; }      
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ModuleActionName { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
        public string Code { get; set; }

        public bool Checked { get; set; }
     
    }

   
}
