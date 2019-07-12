using Microsoft.EntityFrameworkCore;
using ND.Data.EF.DBContext;
using ND.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ND.Repository.EF
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        private NDDbContext dbcontext = null;
        public RepositoryBase(NDDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }


        public List<TEntity> FindList(string strSql)
        {
            return dbcontext.Set<TEntity>().FromSql(strSql).ToList<TEntity>();
        }

        public List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        {
            return dbcontext.Set<TEntity>().FromSql(strSql).ToList<TEntity>();
        }
    }
}
