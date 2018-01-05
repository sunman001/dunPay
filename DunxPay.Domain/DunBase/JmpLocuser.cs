/**********************************************
文件名：jmp_locuser.cs
作者：dunxingpay.com
日期：2017/11/15
描述：数据表[jmp_locuser]实体类
**********************************************/
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{
    /// <summary>
    /// 数据表[jmp_locuser]实体类
    /// </summary>
    [Alias("jmp_locuser")]
	public class JmpLocuser
	{	       
        /// <summary>
        /// 主键
        /// </summary>
        [AutoIncrement,PrimaryKey]
        [Alias("u_id")]
    	public int UId { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        [Alias("u_role_id")]
    	public int URoleId { get; set; }
        /// <summary>
        /// 登陆名
        /// </summary>
        [Alias("u_loginname")]
    	public string ULoginname { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Alias("u_pwd")]
    	public string UPwd { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        [Alias("u_realname")]
    	public string URealname { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Alias("u_department")]
    	public string UDepartment { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        [Alias("u_position")]
    	public string UPosition { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Alias("u_count")]
    	public int UCount { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Alias("u_state")]
    	public int UState { get; set; }
        /// <summary>
        /// u_mobilenumber
        /// </summary>
        [Alias("u_mobilenumber")]
    	public string UMobilenumber { get; set; }
        /// <summary>
        /// u_emailaddress
        /// </summary>
        [Alias("u_emailaddress")]
    	public string UEmailaddress { get; set; }
        /// <summary>
        /// u_qq
        /// </summary>
        [Alias("u_qq")]
    	public string UQq { get; set; }
        /// <summary>
        /// 用户类型[-1:超级管理员,0:一般管理员,1:一般用户],默认值:1
        /// </summary>
        [Alias("u_type")]
    	public int? UType { get; set; }
	}
}