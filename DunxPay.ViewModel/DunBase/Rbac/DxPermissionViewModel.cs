using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.Rbac
{
    public class DxPermissionViewModel
    {
        public DxPermissionViewModel()
        {
            DxPerMissionAction = new List<DxPerMissionAction>();
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int  RoleId { get; set; }
        public List<DxPerMissionAction> DxPerMissionAction { get; set; }

    }

    public class DxPerMissionAction
    {
        /// <summary>
        ///模块编号
        /// </summary>
        public string ModuleIdentifyCode { get; set; }
        /// <summary>
        /// 操作码
        /// </summary>
        public string Code { get; set; }
    }
}
