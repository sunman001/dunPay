using DunxPay.Global;
using DunxPay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DunxPay.Services
{
    /// <summary>
    /// 泛型服务基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericService<T> : IService<T>, IDependency where T : class, new()
    {
        private readonly IRepository<T> _repository;

        protected GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public T FindById(int id)
        {
            return _repository.FindById(id);
        }

        /// <summary>
        /// 查询所有数据(无分页,请慎用)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            return _repository.FindListByClause(predicate, orderBy);
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
            return _repository.FindPagedList(predicate, orderBy, pageIndex, pageSize);
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
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderField = "", string orderBySort = "ASC", int pageIndex = 1,
            int pageSize = 20)
        {
            return _repository.FindPagedList(predicate, orderField, orderBySort, pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <returns></returns>
        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> orderByExpression, int pageIndex = 1, int pageSize = 20)
        {
            return _repository.FindPagedList(predicate, orderByExpression, pageIndex, pageSize);
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        /// <summary>
        /// 删除指定实体的数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        /// <summary>
        /// 根据表达式树删除实体数据
        /// </summary>
        /// <param name="where">条件表达式树</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> @where)
        {
            return _repository.Delete(@where);
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            return _repository.DeleteById(id);
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteByIds(object[] ids)
        {
            return _repository.DeleteByIds(ids);
        }

        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindByClause(predicate);
        }
    }
}