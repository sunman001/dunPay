/**********************************************
文件名：DxUserRoleMappingService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[用户-角色关系映射表]服务实现
**********************************************/
using DunxPay.Domain.DunBase;
using DunxPay.Repositories;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxUserRoleMappingService : GenericService<DxUserRoleMapping>, IDxUserRoleMappingService
    {
        private readonly IDxUserRoleMappingRepository _repository;
        public DxUserRoleMappingService(IDxUserRoleMappingRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}