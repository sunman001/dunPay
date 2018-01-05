/**********************************************
文件名：DxPermissionActionService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[权限-操作关系映射表]服务实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxPermissionActionService : GenericService<DxPermissionAction>, IDxPermissionActionService
    {
        private readonly IDxPermissionActionRepository _repository;
        public DxPermissionActionService(IDxPermissionActionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool BatchInsert(List<DxPermissionAction> list)
        {
            return _repository.BatchInsert(list);
        }
    }
}