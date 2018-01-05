/**********************************************
文件名：DxRoleRepository.cs
作者：dunxingpay.com
日期：2017/10/27
描述：[角色信息表]仓储层实现
**********************************************/

using System;
using System.Collections.Generic;
using System.Data;
using DunxPay.Domain.DunBase;
using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Repositories.Inter.DunBase;
using Infrastructure;
using ServiceStack.OrmLite;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class DxRoleRepository : BaseGenericRepository<DxRole>, IDxRoleRepository
    {

        /// <summary>
        /// 根据用户ID修改用户状态
        /// </summary>
        /// <param name="start">禁用启用状态</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool UpdateStart(int start, string id)
        {
            using (var db = DbFactory.GetConnection)
            {
                var sql = @"update DxRole set IsEnabled=@start where Id in(" + id + ") ";

                int num = db.ExecuteSql(sql, new { start = start });

                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<RolePermissionQueryModel> FindPerssionByRoleId(int RoleId)
        {
            using (var db = DbFactory.GetConnection)
            {
                var module = @"	select a.ModuleIdentifyCode,b.Code, a .IdentifyCode  from DxPermission a  left join DxPermissionAction b on a.IdentifyCode=b.PermissionIdentifyCode
         left join DxRole c on a.RoleIdentifyCode=c.IdentifyCode
       where c.id=" + RoleId + "";
                var entity = db.SqlList<RolePermissionQueryModel>(string.Format("{0}", module));
                return entity;
            }
        }

        public bool DeleteByIdentityCode(string IdentifyCode)
        {
            using (var db = DbFactory.GetConnection)
            {
                var q = db.From<DxPermission>()
                    .Join<DxPermissionAction>((x, y) => x.IdentifyCode == y.PermissionIdentifyCode)
                    .Where<DxPermission>(x => x.IdentifyCode == IdentifyCode);

                int a = db.Delete(q);
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
        }
        /// <summary>
        /// 权限设置加事务
        /// </summary>
        /// <param name="IsDeteled"></param>
        /// <param name="IdentifyCode"></param>
        /// <param name="DxPermissionList"></param>
        /// <param name="DxPermissionActionList"></param>
        /// <returns></returns>
        public bool PermissionSet(bool IsDeteled, List<string> IdentifyCode, List<DxPermission> DxPermissionList, List<DxPermissionAction> DxPermissionActionList)
        {
            using (var db = DbFactory.GetConnection)
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        if (IsDeteled)
                        {//删除原有的权限信息
                            foreach (var code in IdentifyCode)
                            {
                                var sql = @"delete DxPermission where IdentifyCode='"+code+"'";
                                db.ExecuteSql(sql);
                                var sql1 = @"delete DxPermissionAction where PermissionIdentifyCode='" + code + "'";
                                db.ExecuteSql(sql1);
                                //var q = db.From<DxPermission>()
                                //    .Join<DxPermissionAction>((x, y) => x.IdentifyCode == y.PermissionIdentifyCode)
                                //    .Where<DxPermission>(x => x.IdentifyCode == code);
                                //    db.Delete(q);
                            }
                        }
                        //添加权限信息
                        if (DxPermissionList.Count>0)
                        {
                            db.SaveAll(DxPermissionList);                            
                        }
                        if (DxPermissionActionList.Count>0)
                        {
                              db.SaveAll(DxPermissionActionList);
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        return false;
                    }

                }
            }
        }
    }
}