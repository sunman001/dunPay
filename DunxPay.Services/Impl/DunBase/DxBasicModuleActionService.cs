/**********************************************
文件名：DxModuleActionService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[模块-操作信息表]服务实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxBasicModuleActionService : GenericService<DxBasicsModuleAction>, IDxBasicsModuleActionService
    {
        private readonly IDxBasicsModuleActionRepository _repository;
        public DxBasicModuleActionService(IDxBasicsModuleActionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        
    }
}