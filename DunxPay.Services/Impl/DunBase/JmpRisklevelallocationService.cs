/**********************************************
文件名：JmpRisklevelallocationService.cs
作者：dunxingpay.com
日期：2017/12/20
描述：[风险等级表]服务实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;
using DunxPay.ViewModel.DunBase.App;

namespace DunxPay.Services.Impl.DunBase
{
    public class JmpRisklevelallocationService : GenericService<JmpRisklevelallocation>, IJmpRisklevelallocationService
    {
        private readonly IJmpRisklevelallocationRepository _repository;
        public JmpRisklevelallocationService(IJmpRisklevelallocationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<RisklevelallocationViewModel> FindRiskLevelByApptypeId(int ApptypeId)
        {
            return _repository.FindRiskLevelByApptypeId(ApptypeId);
        }
    }
}