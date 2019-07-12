using Microsoft.EntityFrameworkCore;
using ND.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ND.Data.EF.DBContext
{
    public class NDDbContext : DbContext
    {
        public NDDbContext(DbContextOptions options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string executingAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string mappingAssemblePath = Path.Combine(executingAssemblyDirectory, "ND.Model.Mapping.dll");

            if (!File.Exists(mappingAssemblePath))
                throw new Exception($"{mappingAssemblePath}文件不存在");

            Assembly asm = Assembly.LoadFile(mappingAssemblePath);

            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                object configurationInstance = Activator.CreateInstance(type);

                modelBuilder.AddConfiguration(type, configurationInstance);
            }
            //modelBuilder.AddConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<UserModel> users { get; set; }
    }
}
