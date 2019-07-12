using System;
using System.Collections.Generic;
using System.Text;

namespace ND.ConsoleTest
{
    public class A
    {
        private I _impl;
         
        public I Ipml
        {
            get { return this._impl; }
            set { this._impl = value; }
        }

        public void testA(string param)
        {
            Console.WriteLine(_impl.test(param));
        }
    }
    public interface I
    {
        string test(string param);
    }
    public class B : I
    {
        public string test(string param)
        {
            return "class B: " + param;
        }
    }

}
