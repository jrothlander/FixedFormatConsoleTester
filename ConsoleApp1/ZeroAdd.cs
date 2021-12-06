
using Extensions;
using System;

namespace ConsoleApp1
{
    public class ZeroAdd : IFixedFormat
    {
        [Length(3), Decimals(1)] public decimal B = 10.0M;
        [Length(3), Decimals(1)] public decimal C = 32.0M;
        [Length(2), Decimals(0)] public decimal D = -10;
        [Length(5), Decimals(2)] public decimal V;
        
        //public ZeroAdd()
        //{
        //    Test();
        //    HalfAdjustTest();
        //}

        public void Test()
        {
            V = B + C;                              // V = 042.00d
            V = B + D;                              // V = 0
            V = C;                                  // V = 032.00

            Console.WriteLine($" B:{B.Fixed("B")}");
            Console.WriteLine($" C:{C.Fixed("C")}");
            Console.WriteLine($" D:{D.Fixed("D")}");
            Console.WriteLine($" V:{V.Fixed("V")}");
        }

        [Length(3), Decimals(1)] public decimal E = 035M;
        [Length(3), Decimals(1)] public decimal F = 4671M;
        [Length(6), Decimals(2)] public decimal G = 0M;

        public void HalfAdjustTest()
        {
            G = F / E;                              

            Console.WriteLine($" G:{G.Fixed("G")}");
        }

        [Length(3), Decimals(1)] public decimal H = 1198.67M;
        [Length(3), Decimals(1)] public decimal I = 0.5M;
        [Length(6), Decimals(2)] public decimal J = 0M;
        public void HalfAdjustTest2()
        {
            J = H + I;

            Console.WriteLine($" J:{J.Fixed("J")}");
        }

    }

}

