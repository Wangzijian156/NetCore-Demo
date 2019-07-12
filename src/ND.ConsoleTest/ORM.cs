using System;
using System.Collections.Generic;
using System.Text;

namespace ND.ConsoleTest
{
    //FileStream fs = new FileStream(@"D:\学习资料\document\NetCore-Demo\document\.net Core Task.txt", FileMode.Open);
    //int fsLen = (int)fs.Length;
    //byte[] heByte = new byte[fsLen];
    //int r = fs.Read(heByte, 0, heByte.Length);
    //string myStr = System.Text.Encoding.UTF8.GetString(heByte);
    //Console.WriteLine(myStr);
    
    //// 系统自动把 Lambda表达式 转为表达式树
    //Expression<Func<int, int, int, int, int>> func = (i, j, x, y) => (i * j) + (x * y);
    //Console.WriteLine(func);
    //// 把代码转为数据
    //var compile = func.Compile();
    //Console.WriteLine(compile);
    //// 代入运算
    //int result = compile(12, 13, 14, 15);
    //Console.WriteLine(result);
     
    //ParameterExpression a = Expression.Parameter(typeof(int), "i");
    //ParameterExpression b = Expression.Parameter(typeof(int), "j");
    //ParameterExpression c = Expression.Parameter(typeof(int), "x");
    //ParameterExpression d = Expression.Parameter(typeof(int), "y");
    //Expression r1 = Expression.Multiply(a, b);      //乘法运行
    //Expression r2 = Expression.Multiply(c, d);      //乘法运行
    //Expression result = Expression.Add(r1, r2);     //相加
    //                                                //生成表达式
    //Expression<Func<int, int, int, int, int>> func = Expression.Lambda<Func<int, int, int, int, int>>(result, a, b, c, d);
    //var com = func.Compile();
    //Console.WriteLine("表达式" + func);
    //        Console.WriteLine(com(12, 12, 13, 13)); 
    //        #endregion

    //        Console.Read();
    //public class A 
    //{
    //    private I impl = new B();
    //    // private I impl = new C();

    //    public void testA(string param)
    //    {
    //        Console.WriteLine(impl.test(param));
    //    }
    //}

    //public interface I
    //{
    //    string test(string param);
    //}

    //public class B : I
    //{
    //    public string test(string param)
    //    {
    //        return "class B: " + param;
    //    }
    //}

    //public class C : I
    //{
    //    public string test(string param)
    //    {
    //        return "class C: " + param;
    //    }
    //}
}
