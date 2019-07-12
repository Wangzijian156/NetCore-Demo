using System;
using System.IO;
using System.Linq.Expressions;

namespace ND.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //B b = new B();  // 创建依赖
            //A a = new A(); 
            //a.Ipml = b;     // 注入依赖
            //a.testA("属性注入");
            try
            {
                Demo222 d = new Demo222();
                double s = d.divide(21, 0);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            Console.Read();
        }
    }
}
