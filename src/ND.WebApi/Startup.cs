using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ND.Data.EF.DBContext;
using ND.WebApi.Configs;

namespace ND.WebApi
{
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository Repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Repository = LogManager.CreateRepository(Configuration["AppSetting:Log4NetName"]);
            //指定配置文件
            XmlConfigurator.Configure(Repository, new FileInfo("Log4net.config"));
        }
         
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<AppSetting>(this.Configuration.GetSection("AppSetting"));

            #region DBConnectStr
            //services.AddDbContext<MyContext>(o => o.UseSqlServer(connectionString));
            var connection = Configuration["ConnectionStrings"];
            services.AddDbContext<NDDbContext>(options => options.UseMySQL(connection));
            #endregion

            #region Autofoc 
            var containerBuilder = new ContainerBuilder();
            // 模块化注入
            // AOP 日志拦截器
            containerBuilder.RegisterType<LogServiceInterceptor>();
            // 获取项目路径
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            // 注入Service
            var servicesDllFile = Path.Combine(basePath, Configuration["AppSetting:ServiceModule"]);
            // 直接采用加载文件的方法
            var assemblysServices = Assembly.LoadFile(servicesDllFile);
            // 指定已扫描程序集中的类型注册为提供所有其实现的接口。
            containerBuilder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                .InterceptedBy(typeof(LogServiceInterceptor));//可以直接替换拦截器

            var repositoryDllFile = Path.Combine(basePath, Configuration["AppSetting:RepositoryModule"]);
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            containerBuilder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            // 将services填充到Autofac容器生成器中 
            containerBuilder.Populate(services);
            #endregion

            return new AutofacServiceProvider(containerBuilder.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Values}/{action=get}/{id?}");
            });
        }
    }
}
