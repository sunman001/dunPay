using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
  public   class PaymodeService :GenericService<jmp_paymode>, IPaymodeService
    {
        private readonly IPaymodeRepository _repository;
        public PaymodeService(IPaymodeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
