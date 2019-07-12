using ND.Data.EF.DBContext;
using ND.IRepository;
using ND.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ND.Repository.EF
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(NDDbContext dbContext) : base(dbContext)
        {

        }
    }
}
