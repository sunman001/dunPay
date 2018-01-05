using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.ViewModel.DunBase.UserManagement
{
    public class DeveloperViewModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int u_id { get; set; }

        /// <summary>
        /// 登录邮件地址
        /// </summary>
        public string u_email { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string u_realname { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string u_phone { get; set; }

        /// <summary>
        /// 联系qq
        /// </summary>  
        public string u_qq { get; set; }

        /// <summary>
        /// 开户银行全称
        /// </summary>
        public string u_bankname { get; set; }

        /// <summary>
        /// 开户名称
        /// </summary>
        public string u_name { get; set; }

        /// <summary>
        /// 开户账号
        /// </summary>
        public string u_account { get; set; }

        /// <summary>
        /// 类别：0 个人 1 企业
        /// </summary>
        public int u_category { get; set; }

        /// <summary>
        /// 账户状态：0 冻结 1 正常
        /// </summary>
        public int u_state { get; set; }

        /// <summary>
        /// 审核状态：-1 未通过 0 等待审核
        /// </summary>
        public int u_auditstate { get; set; }

        /// <summary>
        /// 关联关系[0:未指定,1:商务,2:代理商]
        /// </summary>
        public int relation_type { get; set; }

        /// <summary>
        /// 关联的关系人ID
        /// </summary>
        public int relation_person_id { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? u_time { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string u_auditor { get; set; }

        /// <summary>
        /// 是否签订合同
        /// </summary>
        public bool IsSignContract { get; set; }

        /// <summary>
        /// 是否备案
        /// </summary>
        public bool IsRecord { get; set; }

        /// <summary>
        /// 商务姓名
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// 代理商姓名
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string u_idnumber { get; set; }

        /// <summary>
        /// 营业执照编号
        /// </summary>
        public string u_blicensenumber { get; set; }
    }
}
