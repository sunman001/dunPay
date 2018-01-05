using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.Rbac
{
   public  class DxModuleJsonModel
    {
        public DxModuleJsonModel()
        {
            Children = new List<DxModuleJsonModel>();
            DxModuleActionModel = new List<DxModuleActionModel>();
        }

        /// <summary>
        /// 菜单标识码
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级标识码
        /// </summary>
        public string  ParentId { get; set; }

        public List<DxModuleJsonModel> Children { get; set; }
        
        public List< DxModuleActionModel> DxModuleActionModel { get; set; }
    }

    public class DxModuleActionModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool Checked { get; set; }
    }
}
