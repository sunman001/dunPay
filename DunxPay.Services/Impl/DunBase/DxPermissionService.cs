/**********************************************
文件名：DxPermissionService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[模块-角色关系映射表]服务实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxPermissionService : GenericService<DxPermission>, IDxPermissionService
    {
        private readonly IDxPermissionRepository _repository;
        public DxPermissionService(IDxPermissionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool BatchInsert(List<DxPermission> list)
        {
            return _repository.BatchInsert(list);
        }
    }
}