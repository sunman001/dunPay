using DunxPay.Global;
using Infrastructure;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DunxPay.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T>, IDependency where T : class, new()
    {
        protected abstract AbstractDbConnectionFactory DbFactory { get; }


        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public T FindById(int id)
        {
            using (var db = DbFactory.GetConnection)
            {
                var entity = db.SingleById<T>(id);
                return entity;
            }
        }

        /// <summary>
        /// 查询所有数据(无分页,请慎用)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            using (var db = DbFactory.GetConnection)
            {
                var list = db.Select<T>();
                return list;
            }
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="predicate">条件表达式树</param>
        /// <param name="orderBy">排序</param>
        /// <returns></returns>
        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy)
        {
            using (var db = DbFactory.GetConnection)
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (!string.IsNullOrEmpty(orderBy))
                {
                    expression = expression.OrderBy(orderBy);
                }
                var list = db.Select(expression);
                return list;
            }
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="predicate">条件表达式树</param>
        /// <returns></returns>
        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            using (var db = DbFactory.GetConnection)
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                var list = db.Single(expression);
                return list;
            }
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbFactory.GetConnection)
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (!string.IsNullOrEmpty(orderBy))
                {
                    expression = expression.OrderBy(orderBy);
                }
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                expression = expression.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var entities = db.Select(expression);
                var totalCount = db.Count(predicate);
                var list = new PagedList<T>(entities, pageIndex, pageSize, (int)totalCount);
                return list;
            }
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderBySort">排序方向</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderField = "", string orderBySort = "ASC", int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbFactory.GetConnection)
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (!string.IsNullOrEmpty(orderField))
                {
                    var modelInfo = typeof(T).GetModelMetadata();
                    var field = modelInfo.FieldDefinitionsWithAliases.FirstOrDefault(x => x.Name.ToLower() == orderField.ToLower());
                    var alias = orderField;
                    if (field != null)
                    {
                        alias = field.Alias;
                    }
                    expression = expression.OrderBy(alias + " " + orderBySort);
                }
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                expression = expression.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var entities = db.Select(expression);
                var totalCount = db.Count(predicate);
                var list = new PagedList<T>(entities, pageIndex, pageSize, (int)totalCount);
                return list;
            }
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderByExpression, int pageIndex = 1, int pageSize = 20)
        {
            using (var db = DbFactory.GetConnection)
            {
                var expression = db.From<T>();
                if (predicate != null)
                {
                    expression = expression.Where(predicate);
                }
                if (orderByExpression != null)
                {
                    expression = expression.OrderBy(orderByExpression);
                }
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                expression = expression.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var entities = db.Select(expression);
                var totalCount = db.Count(predicate);
                var list = new PagedList<T>(entities, pageIndex, pageSize, (int)totalCount);
                return list;
            }
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            using (var db = DbFactory.GetConnection)
            {
                return (int)db.Insert(entity, true);
            }
        }

        /// <summary>
        /// 新增或者修改
        /// 如果没有记录，就会插入，否则就会更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool Save(T entity)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.Save(entity);
            }
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.Update(entity) > 0;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.Delete(entity) > 0;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> @where)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.Delete(@where) > 0;
            }
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.DeleteById<T>(id) > 0;
            }
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            using (var db = DbFactory.GetConnection)
            {
                return db.DeleteByIds<T>(ids) > 0;
            }
        }


        /// <summary>
        /// 封装分页存储过程
        /// </summary>
        /// <typeparam name="TResult">T</typeparam>
        /// <param name="sql">sql 语句</param>
        /// <param name="orderBy">排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        protected IPagedList<TResult> ExecuteProc<TResult>(string sql, string orderBy, int pageIndex = 0, int pageSize = 20)
        {
            using (var db = DbFactory.GetConnection)
            {
                using (var cmd = db.SqlProc("SqlPager"))
                {
                    cmd.AddParam("Sql", sql);
                    cmd.AddParam("Order", orderBy);
                    cmd.AddParam("pageIndex", pageIndex);
                    cmd.AddParam("pageSize", pageSize);
                    var stat = cmd.AddParam("TotalCount", direction: ParameterDirection.Output);
                    var list = cmd.ConvertToList<TResult>().ToList();
                    var count = stat.Value;
                    var items = new PagedList<TResult>(list, pageIndex, pageSize, int.Parse(count.ToString()));
                    return items;
                }
            }
        }

    }
}
