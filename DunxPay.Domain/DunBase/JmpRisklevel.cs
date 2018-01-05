/**********************************************
文件名：jmp_risklevel.cs
作者：dunxingpay.com
日期：2017/12/20
描述：数据表[风险等级类型表]实体类
**********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{	
    /// <summary>
    /// 数据表[风险等级类型表]实体类
    /// </summary>
    [Alias("jmp_risklevel")]
	public class JmpRisklevel
	{	       
        /// <summary>
        /// 主键自增
        /// </summary>
        [AutoIncrement,PrimaryKey]
        [Alias("r_id")]
    	public int RId { get; set; }
        /// <summary>
        /// 风险等级名称
        /// </summary>
        [Alias("r_name")]
    	public string RName { get; set; }
	}
}