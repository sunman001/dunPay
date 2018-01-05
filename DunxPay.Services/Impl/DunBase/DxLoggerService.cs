
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
   public  class DxLoggerService:GenericService<DxAdminOperationLog>, IDxLoggerService
    {
        private readonly IDxLoggerRepository _repository;
        public DxLoggerService(IDxLoggerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
