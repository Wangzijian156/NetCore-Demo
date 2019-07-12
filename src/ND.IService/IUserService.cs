using ND.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ND.IService
{
    public interface IUserService
    {
        List<UserModel> All();
    }
}
