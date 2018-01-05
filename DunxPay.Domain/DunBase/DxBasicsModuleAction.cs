using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    [Alias("DxBasicsModuleAction")]
    public   class DxBasicsModuleAction
    {
        /// <summary>
        /// 主键
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Icon { get; set; }

        
    }
}
