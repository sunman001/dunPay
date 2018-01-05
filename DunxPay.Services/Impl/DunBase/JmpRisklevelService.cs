/**********************************************
文件名：JmpRisklevelService.cs
作者：dunxingpay.com
日期：2017/12/20
描述：[风险等级类型表]服务实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class JmpRisklevelService : GenericService<JmpRisklevel>, IJmpRisklevelService
    {
        private readonly IJmpRisklevelRepository _repository;
        public JmpRisklevelService(IJmpRisklevelRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}