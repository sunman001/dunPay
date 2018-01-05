using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 应用表
    /// </summary>
    [Alias("jmp_app")]
    public class jmp_app
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int a_id { get; set; }
        /// <summary>
        /// 管理用户ID
        /// </summary>		

        public int a_user_id { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>		

        public string a_name { get; set; }
        /// <summary>
        /// 关联平台ID
        /// </summary>		

        public int a_platform_id { get; set; }
        /// <summary>
        /// 关联支付类型ID
        /// </summary>	
        public string a_paymode_id { get; set; }
        /// <summary>
        /// 关联应用类型ID
        /// </summary>	
        public int a_apptype_id { get; set; }

        /// <summary>
        /// 回掉地址
        /// </summary>	
        public string a_notifyurl { get; set; }
        /// <summary>
        /// 应用密匙
        /// </summary>	

        public string a_key { get; set; }

        /// <summary>
        /// 应用状态（0：冻结，1：正常，-1
        /// </summary>	
        public int a_state { get; set; }

        /// <summary>
        /// 审核状态（0：未审核，1：审核通
        /// </summary>		

        public int a_auditstate { get; set; }

        /// <summary>
        /// 应用秘钥
        /// </summary>	

        public string a_secretkey { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>

        public string a_auditor { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>	

        public DateTime a_time { get; set; }

        /// <summary>
        /// 同步地址
        /// </summary>

        public string a_showurl { get; set; }

        /// <summary>
        /// 风险等级配置表id
        /// </summary>
        public int a_rid { get; set; }

        /// <summary>
        /// 应用审核地址
        /// </summary>
        public string a_appurl { get; set; }

        /// <summary>
        /// 审核地址
        /// </summary>
        public string a_appsynopsis { get; set; }


    }
}
