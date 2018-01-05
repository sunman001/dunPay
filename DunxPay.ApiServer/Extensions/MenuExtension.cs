using DunxPay.ViewModel.DunBase.Rbac;
using System.Collections.Generic;
using System.Linq;

namespace DunxPay.ApiServer.Extensions
{
    /// <summary>
    /// 菜单静态扩展类
    /// </summary>
    public static class MenuExtension
    {
        /// <summary>
        /// 根据菜单数据集生成无限级菜单树
        /// </summary>
        /// <param name="source">菜单数据集</param>
        /// <returns>菜单树泛型集合</returns>
        public static List<MenuJsonModel> BuildTreeMenu(this List<MenuJsonModel> source)
        {
            var tmp = new List<MenuJsonModel>();
            if (source.Count <= 0) return tmp;
            tmp = source.Where(menu => string.IsNullOrEmpty(menu.ParentIdentifyCode )).ToList();

            foreach (var menuItem in tmp)
            {
                RecursiveBuilder(menuItem, source);
            }
            return tmp;
        }

        /// <summary>
        /// 菜单树内部子节点的递归方法
        /// </summary>
        /// <param name="menuItem">当前父级菜单</param>
        /// <param name="menudata">子菜单集合</param>
        private static void RecursiveBuilder(MenuJsonModel menuItem, List<MenuJsonModel> menudata)
        {
            var menuItems = menudata.Where(menu => menu.ParentIdentifyCode == menuItem.IdentifyCode).ToList();

            if (!menuItems.Any()) return;
            foreach (var item in menuItems)
            {
                //item.ParentId = menuItem.Id;
                item.Text = item.Name;
                menuItem.Children.Add(item);
                RecursiveBuilder(item, menudata);
            }
        }
    }
}