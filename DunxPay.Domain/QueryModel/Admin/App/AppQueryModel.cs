using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.Domain.QueryModel.Admin.App
{
    /// <summary>
    /// 应用查询表
    /// </summary>
  public   class AppQueryModel
    {

        /// <summary>
        /// 应用ID
        /// </summary>	
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
        /// 登录邮件地址
        /// </summary>
        public string u_email { get; set; }
        /// <summary>
        /// 同步地址
        /// </summary>
        public string a_showurl { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string u_realname { get; set; }

        /// <summary>
        /// 所属应用类型
        /// </summary>
        public string t_name { get; set; }

        /// <summary>
        /// 所属平台
        /// </summary>
        public string p_name { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int u_id { get; set; }

        /// <summary>
        /// 风险等级配置表id(添加时默认为0)
        /// </summary>
        public int a_rid { get; set; }
        /// <summary>
        /// 应用审核地址
        /// </summary>
     
        public string a_appurl { get; set; }

        /// <summary>
        /// 应用简介
        /// </summary>
        public string a_appsynopsis { get; set; }

        /// <summary>
        /// 风控高中低表ID
        /// </summary>
        public int r_id { get; set; }

        /// <summary>
        /// 风控高中低
        /// </summary>
        public string r_name { get; set; }

    
}
}
