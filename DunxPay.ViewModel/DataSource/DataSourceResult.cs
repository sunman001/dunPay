using DunxPay.Global;
using System.Collections;
using System.Collections.Generic;

namespace DunxPay.ViewModel.DataSource
{
    /// <summary>
    /// 数据源泛型实体
    /// </summary>
    /// <typeparam name="T">泛型对象</typeparam>
    public class DataSourceResult<T>
    {
        public DataSourceResult(IPagedList<T> list)
        {
            Total = list.TotalCount;
        }
        /// <summary>
        /// 附加信息(可选)
        /// </summary>
        public object ExtraData { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public IEnumerable Rows { get; set; }
        /// <summary>
        ///错误提示(可选)
        /// </summary>
        public object Errors { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 初始化页面分页大小的选择列表
        /// </summary>
        public List<int> PageList { get; set; }
    }
}