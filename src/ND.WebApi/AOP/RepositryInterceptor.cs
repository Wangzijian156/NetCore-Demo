using Castle.DynamicProxy;
using log4net;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace ND.WebApi.Configs
{
    public class RepositryInterceptor : IInterceptor
    {

        public RepositryInterceptor() {  }

        /// <summary>
        /// 实例化IInterceptor唯一方法 
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            var dataIntercept = "" +
                $"【当前执行方法】：{ invocation.Method.Name} \r\n" +
                $"【携带的参数有】： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";
            try
            {
                //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
                invocation.Proceed();
            }
            catch (Exception e)
            {
                // 捕获异常
                dataIntercept += ($"方法执行中出现异常：{e.Message + e.InnerException}\r\n");
                //_logger.Error(dataIntercept);
            }
            //dataIntercept += ($"【执行完成结果】：{invocation.ReturnValue}");
            //_logger.Info(dataIntercept);
        }


    }
}
