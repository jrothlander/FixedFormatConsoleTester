
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

    }

}

