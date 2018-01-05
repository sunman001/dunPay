/**********************************************
文件名：jmp_risklevelallocation.cs
作者：dunxingpay.com
日期：2017/12/20
描述：数据表[风险等级表]实体类
**********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace DunxPay.Domain.DunBase
{	
    /// <summary>
    /// 数据表[风险等级表]实体类
    /// </summary>
    [Alias("jmp_risklevelallocation")]
	public class JmpRisklevelallocation
	{	       
        /// <summary>
        /// 主键自增
        /// </summary>
        [AutoIncrement,PrimaryKey]
        [Alias("r_id")]
    	public int RId { get; set; }
        /// <summary>
        /// 应用类型父级id
        /// </summary>
        [Alias("r_apptypeid")]
    	public int RApptypeid { get; set; }
        /// <summary>
        /// 关联风险等级表id
        /// </summary>
        [Alias("r_risklevel")]
    	public int RRisklevel { get; set; }
        /// <summary>
        /// 状态（0：正常，1冻结）
        /// </summary>
        [Alias("r_state")]
    	public int RState { get; set; }
	}
}