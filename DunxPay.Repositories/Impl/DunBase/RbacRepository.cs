using DunxPay.Domain.QueryModel.Admin.User;
using DunxPay.Global;
using DunxPay.Repositories.Inter.DunBase;
using Infrastructure;
using ServiceStack.OrmLite;
using System.Collections.Generic;

namespace DunxPay.Repositories.Impl.DunBase
{
    public class RbacRepository : IRbacRepository, IDependency
    {
        private readonly AbstractDbConnectionFactory _dbFactory = new BaseDbConnectionFactory();


        public List<MenuQueryModel> FindMenusByUserIdAndClientId(int userId, string clientId, bool isSuperAdmin = false)
        {
            using (var db = _dbFactory.GetConnection)
            {
                var module = "";
                if (isSuperAdmin)
                {
                    module = @";with t as(
	SELECT * FROM dbo.DxModule AS M WHERE M.IsEnabled=1 AND M.IsDeleted=0 AND ClientId=@ClientId
), cte AS (
	SELECT dm.Id, dm.Name,dm.IdentifyCode, ParentIdentifyCode,dm.RequestUrl,dm.Icon,dm.Sort,dm.Description,dm.ChildCount, 0 AS Level
    FROM t as dm
    WHERE dm.ParentIdentifyCode=''
    UNION ALL
    SELECT m.Id, m.Name,m.IdentifyCode, m.ParentIdentifyCode,m.RequestUrl,m.Icon,m.Sort,m.Description,m.ChildCount, Level + 1 AS Level
    FROM t as m INNER JOIN cte ON M.ParentIdentifyCode = cte.IdentifyCode
)
SELECT * from cte order by cte.Level";
                }
                else
                {
                    module = @";with t as(
	SELECT * FROM dbo.DxModule AS M WHERE M.IsEnabled=1 AND M.IsDeleted=0 AND EXISTS (
	SELECT * FROM dbo.DxPermissionAction AS DPA INNER JOIN dbo.DxPermission AS DP ON DP.IdentifyCode=DPA.PermissionIdentifyCode 
	WHERE DP.IsEnabled=1 AND DPA.IsEnabled=1 AND DP.ModuleIdentifyCode=M.IdentifyCode AND EXISTS (
		SELECT RoleIdentifyCode FROM DxUserRoleMapping AS DUR WHERE DUR.RoleIdentifyCode =DP.RoleIdentifyCode AND UserId = @UserId
		)
	)
), t1 as(
	select t.Id, t.Name,t.IdentifyCode, ParentIdentifyCode,t.RequestUrl,t.Icon,t.Sort,t.Description,t.ChildCount,t.ClientId,t.ClientName,t.IsEnabled,t.IsDeleted from t 
	inner join dbo.DxPermission as dp on dp.ModuleIdentifyCode=t.IdentifyCode
	where t.ClientId=@ClientId  AND EXISTS 
		(
			SELECT RoleIdentifyCode FROM DxUserRoleMapping AS DUR WHERE DUR.RoleIdentifyCode =DP.RoleIdentifyCode AND UserId = @UserId
		)
), cte AS (
	SELECT dm.Id, dm.Name,dm.IdentifyCode, ParentIdentifyCode,dm.RequestUrl,dm.Icon,dm.Sort,dm.Description,dm.ChildCount,dm.ClientId,dm.ClientName,dm.IsEnabled,dm.IsDeleted, 0 AS Level
    FROM t1 as dm
    WHERE dm.ParentIdentifyCode=''
    UNION ALL
    SELECT m.Id, m.Name,m.IdentifyCode, m.ParentIdentifyCode,m.RequestUrl,m.Icon,m.Sort,m.Description,m.ChildCount,m.ClientId,m.ClientName,m.IsEnabled,m.IsDeleted, Level + 1 AS Level
    FROM t1 as m INNER JOIN cte ON M.ParentIdentifyCode = cte.IdentifyCode)

SELECT * from cte order by cte.Level";
                }
                var entity = db.SqlList<MenuQueryModel>(module, new { UserId = userId, ClientId = clientId });
                return entity;
            }
        }

        #region Implementation of IJmpLocuserRepository

        /// <summary>
        /// 根据用户ID查询可用的权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isSuperAdmin">是否是超级管理员</param>
        /// <returns></returns>
        public List<PermissionQueryModel> FindPermissions(int userId, bool isSuperAdmin = false)
        {
            using (var db = _dbFactory.GetConnection)
            {
                var sql = @";with t as
(
	select 
	dpa.Code as ActionCode,dma.Name as ActionName,dma.IsButton,dma.ButtonType,dma.JsOperatingFunction,dma.ButtonIcon
	,dp.IdentifyCode,dp.ModuleIdentifyCode,dp.RoleIdentifyCode
	,dm.RequestUrl,dm.Name as ModuleName,dm.Code as ModuleCode,dm.ClientId
	from dbo.DxPermissionAction as dpa
	inner join dbo.DxPermission as dp on dp.IdentifyCode=dpa.PermissionIdentifyCode
	inner join dbo.DxModule as dm on dm.IdentifyCode=dp.ModuleIdentifyCode
	inner join dbo.DxRole as dr on dr.IdentifyCode=dp.RoleIdentifyCode
	inner join dbo.DxModuleAction as dma on dma.ModuleIdentifyCode=dm.IdentifyCode and dma.Code=dpa.Code
	where dpa.IsEnabled=1 and dp.IsEnabled=1 and dm.IsEnabled=1 and dm.IsDeleted=0 and dr.IsEnabled=1 and dr.IsDeleted=0 and dma.IsEnabled=1
), r as
(
	select * from dbo.DxUserRoleMapping as durm where durm.UserId=@UserId
)
select t.ModuleName,t.ModuleCode,t.ActionName,t.ActionCode,t.RequestUrl,t.ClientId,t.IsButton,t.ButtonType,t.JsOperatingFunction,t.ButtonIcon from t where exists (select r.RoleIdentifyCode from r where r.RoleIdentifyCode=t.RoleIdentifyCode)";
                if (isSuperAdmin)
                {
                    sql =
                        @"select dm.name as ModuleName,dm.code as ModuleCode,dma.Name as ActionName, dma.IsButton,dma.ButtonType,dma.JsOperatingFunction,dma.ButtonIcon,dma.code as ActionCode,dm.RequestUrl,dm.ClientId from dbo.DxModuleAction as dma 
inner join dbo.DxModule as dm on dm.IdentifyCode=dma.ModuleIdentifyCode 
where dma.IsEnabled=1 and dm.IsEnabled=1 and dm.IsDeleted=0";
                }
                var list = db.SqlList<PermissionQueryModel>(sql, new { UserId = userId });
                return list;
            }
        }

        #endregion
    }
}
