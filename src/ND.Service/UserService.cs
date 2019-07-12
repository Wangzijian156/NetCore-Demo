using ND.IRepository;
using ND.IService;
using ND.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ND.Service
{
    public class UserService : IUserService
    {
        private IUserRepository service;
        public UserService(IUserRepository userRepository)
        {
            this.service = userRepository;
        }

        public List<UserModel> All()
        {
            List<UserModel> list = service.FindList("SELECT id as ID,username as UserName,password as Password,age as Age,birth as Birth,email as Email,phone as Phone,createtime as CreateTime,updatetime as UpdateTime FROM sys_user;");
            return list;
        }
    }
}
