using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var add = new Add();
            //add.AddTest();
            //add.TruncationTest_Failure();
            //add.TruncationTest_Success();          

            var zadd = new ZeroAdd();
            zadd.Test();

            Console.ReadKey();
        }
    }
}
