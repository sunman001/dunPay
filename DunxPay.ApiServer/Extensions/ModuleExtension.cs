using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.ViewModel.DunBase.Rbac;

namespace DunxPay.ApiServer.Extensions
{
    public static class ModuleExtension
    {

        public static List<DxModuleJsonModel> BuildTreeMenu(this List<ModuleQueryModel> source)
        {
            var tmp = new List<ModuleQueryModel>();

            var tmpjson = new List<DxModuleJsonModel>();
            if (source.Count <= 0) return tmpjson;
            tmp = source.Where(menu => menu.ParentIdentifyCode.Trim().Length <= 0).Distinct().ToList();
            foreach (var module in tmp)
            {
                var model = new DxModuleJsonModel
                {
                    Id = module.IdentifyCode,
                    ParentId = module.ParentIdentifyCode,
                    Name = module.Name
                };
                tmpjson.Add(model);
            }

            foreach (var menuItem in tmpjson)
            {
                RecursiveBuilder(menuItem, source);
            }

            return tmpjson;
        }

        /// <summary>
        /// 菜单树内部子节点的递归方法
        /// </summary>
        /// <param name="menuItem">当前父级菜单</param>
        /// <param name="menudata">子菜单集合</param>
        private static void RecursiveBuilder(DxModuleJsonModel menuItem, List<ModuleQueryModel> menudata)
        {
            var menuItems = menudata.Where(menu => menu.ParentIdentifyCode == menuItem.Id).Select(x => new
            {
                x.IdentifyCode,
                x.ParentIdentifyCode,
                x.Name
            }).Distinct().ToList();


            if (!menuItems.Any()) return;
            foreach (var item in menuItems)
            {
                var model = new DxModuleJsonModel
                {
                    Id = item.IdentifyCode,
                    ParentId = item.ParentIdentifyCode,
                    Name = item.Name
                };
                
                var actions = menudata.FindAll(x => x.IdentifyCode == model.Id).Select(x =>
                    new DxModuleActionModel
                    {
                        Code = x.Code,
                        Name = x.ModuleActionName,
                        Checked = x.Checked
                       
                    }).ToList();
                model.DxModuleActionModel = actions;
                menuItem.Children.Add(model);
                RecursiveBuilder(model, menudata);
            }
        }
    }
}