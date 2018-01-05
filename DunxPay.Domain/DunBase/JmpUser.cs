/**********************************************
文件名：jmp_user.cs
作者：dunxingpay.com
日期：2017/12/20
描述：数据表[jmp_user]实体类
**********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{	
    /// <summary>
    /// 数据表[jmp_user]实体类
    /// </summary>
    [Alias("jmp_user")]
	public class JmpUser
	{	       
        /// <summary>
        /// 用户ID
        /// </summary>
        [AutoIncrement,PrimaryKey]
        [Alias("u_id")]
    	public int UId { get; set; }
        /// <summary>
        /// 登录邮件地址
        /// </summary>
        [Alias("u_email")]
    	public string UEmail { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Alias("u_password")]
    	public string UPassword { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Alias("u_realname")]
    	public string URealname { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Alias("u_phone")]
    	public string UPhone { get; set; }
        /// <summary>
        /// 联系qq
        /// </summary>
        [Alias("u_qq")]
    	public string UQq { get; set; }
        /// <summary>
        /// 开户银行全称
        /// </summary>
        [Alias("u_bankname")]
    	public string UBankname { get; set; }
        /// <summary>
        /// 开户名
        /// </summary>
        [Alias("u_name")]
    	public string UName { get; set; }
        /// <summary>
        /// 开户账号
        /// </summary>
        [Alias("u_account")]
    	public string UAccount { get; set; }
        /// <summary>
        /// 类别：0 个人 1 企业
        /// </summary>
        [Alias("u_category")]
    	public int UCategory { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Alias("u_idnumber")]
    	public string UIdnumber { get; set; }
        /// <summary>
        /// 持证照片地址
        /// </summary>
        [Alias("u_photo")]
    	public string UPhoto { get; set; }
        /// <summary>
        /// 营业执照照片
        /// </summary>
        [Alias("u_blicense")]
    	public string UBlicense { get; set; }
        /// <summary>
        /// 营业执照编号
        /// </summary>
        [Alias("u_blicensenumber")]
    	public string UBlicensenumber { get; set; }
        /// <summary>
        /// 用户登录次数
        /// </summary>
        [Alias("u_count")]
    	public int UCount { get; set; }
        /// <summary>
        /// 账户状态：0 冻结 1 正常
        /// </summary>
        [Alias("u_state")]
    	public int UState { get; set; }
        /// <summary>
        /// 审核状态：-1 未通过 0 等待审核
        /// </summary>
        [Alias("u_auditstate")]
    	public int UAuditstate { get; set; }
        /// <summary>
        /// 父级用户ID(0:父级)
        /// </summary>
        [Alias("u_topid")]
    	public int UTopid { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        [Alias("u_address")]
    	public string UAddress { get; set; }
        /// <summary>
        /// u_role_id
        /// </summary>
        [Alias("u_role_id")]
    	public int? URoleId { get; set; }
        /// <summary>
        /// u_drawing
        /// </summary>
        [Alias("u_drawing")]
    	public int? UDrawing { get; set; }
        /// <summary>
        /// u_merchant_id
        /// </summary>
        [Alias("u_merchant_id")]
    	public int? UMerchantId { get; set; }
        /// <summary>
        /// 关联关系[0:未指定,1:商务,2:代理商]
        /// </summary>
        [Alias("relation_type")]
    	public int? RelationType { get; set; }
        /// <summary>
        /// 关联的关系人ID
        /// </summary>
        [Alias("relation_person_id")]
    	public int? RelationPersonId { get; set; }
        /// <summary>
        /// 开发者服务费关联表ID(商务或者代理商设置此项,根据relation_type字段)
        /// </summary>
    	public int? ServiceFeeRatioGradeId { get; set; }
        /// <summary>
        /// 是否特批(如果是特批,读取系统表[jmp_system]中的CO_SPECIAL_SERVICE_FEE_RATIO选项的值)
        /// </summary>
    	public bool? IsSpecialApproval { get; set; }
        /// <summary>
        /// 特批时需要减掉的服务费率(小数)
        /// </summary>
    	public decimal? SpecialApproval { get; set; }
        /// <summary>
        /// BusinessEntity
        /// </summary>
    	public string BusinessEntity { get; set; }
        /// <summary>
        /// RegisteredAddress
        /// </summary>
    	public string RegisteredAddress { get; set; }
        /// <summary>
        /// u_time
        /// </summary>
        [Alias("u_time")]
    	public DateTime? UTime { get; set; }
        /// <summary>
        /// u_auditor
        /// </summary>
        [Alias("u_auditor")]
    	public string UAuditor { get; set; }
        /// <summary>
        /// u_paypwd
        /// </summary>
        [Alias("u_paypwd")]
    	public string UPaypwd { get; set; }
        /// <summary>
        /// u_photof
        /// </summary>
        [Alias("u_photof")]
    	public string UPhotof { get; set; }
        /// <summary>
        /// u_licence
        /// </summary>
        [Alias("u_licence")]
    	public string ULicence { get; set; }
        /// <summary>
        /// 冻结金额 
        /// </summary>
    	public decimal? FrozenMoney { get; set; }
        /// <summary>
        /// IsSignContract
        /// </summary>
    	public bool? IsSignContract { get; set; }
        /// <summary>
        /// IsRecord
        /// </summary>
    	public bool? IsRecord { get; set; }
	}
}