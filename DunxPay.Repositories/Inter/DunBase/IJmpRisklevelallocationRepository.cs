/**********************************************
文件名：IJmpRisklevelallocationRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[风险等级表]仓储层接口
**********************************************/

using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Repositories.Inter.DunBase
{
    public interface IJmpRisklevelallocationRepository : IRepository<JmpRisklevelallocation>
    {
        /// <summary>
        /// 根据应用子类型查询对应的应用的风险等级
        /// </summary>
        /// <param name="ApptypeId"> 应用类型id</param>
        /// <returns></returns>
        List<RisklevelallocationViewModel> FindRiskLevelByApptypeId(int ApptypeId );
    }
}