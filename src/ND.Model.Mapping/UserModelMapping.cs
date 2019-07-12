using Microsoft.EntityFrameworkCore;
using ND.Data.EF;
using ND.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ND.Model.Mapping
{
    public class UserModelMapping : EntityTypeConfiguration<UserModel>
    {
        //public UserMap()
        //{
        //    this.ToTable("Sys_User");
        //    this.HasKey(t => t.F_Id);
        //}
        //public override void Map(EntityTypeBuilder<UserEntity> builder)
        //{
        //    builder.ToTable("Sys_User");
        //    builder.HasKey(_ => _.F_Id);
        //}

        public override void Map(ModelBuilder builder)
        {
            builder.Entity<UserModel>().ToTable("sys_user").HasKey(_ => _.Id);
            // 添加筛选条件
            //builder.Entity<UserModel>().HasQueryFilter(_ => _.F_DeleteMark != true);
        }
    }
}
