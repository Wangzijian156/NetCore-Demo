﻿using ND.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ND.IRepository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        //int Insert(TEntity entity);
        //int Insert(List<TEntity> entitys);
        //int Update(TEntity entity);
        //int Delete(TEntity entity);
        //int Delete(Expression<Func<TEntity, bool>> predicate);
        //TEntity FindEntity(object keyValue);
        //TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> IQueryable();
        //IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(string strSql);
        List<TEntity> FindList(string strSql, DbParameter[] dbParameter);
        //List<TEntity> FindList(PageModel pageModel);
        //List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, PageModel pageModel);
    }
}
