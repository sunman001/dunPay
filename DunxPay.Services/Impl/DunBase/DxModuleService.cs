/**********************************************
文件名：DxModuleService.cs
作者：dunxingpay.com
日期：2017/11/30
描述：[模块信息表]服务实现
**********************************************/
using System.Collections.Generic;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Repositories.Inter.DunBase;
using DunxPay.Services.Inter.DunBase;

namespace DunxPay.Services.Impl.DunBase
{
    public class DxModuleService : GenericService<DxModule>, IDxModuleService
    {
        private readonly IDxModuleRepository _repository;
        public DxModuleService(IDxModuleRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<MenuQueryModel> FindMenusByClientId(string clientId)
        {
            return _repository.FindMenusByClientId(clientId);
        }

        public List<ModuleQueryModel> FindModuleListByClientId(int ClientId,string  RoleId)
        {
            return _repository.FindModuleListByClientId(ClientId,RoleId);
        }

        public bool UpdateStart(int start, string id)
        {
            return _repository.UpdateStart(start, id);
        }
    }
}