//C*
//     C*   In the following example, the initial field values are:
//     C*
//     D A               s              3p 0  inz(1)
//     D B               s              3p 1  inz(10.0)
//     D C               s              2p 0  inz(32)
//     D D               s              2p 0 inz(-10)
//     D E               s              3p 0 inz(6)
//     D F               s              3p 0 inz(10)
//     D G               s              3p 2 inz(2.77)
//     D H               s              3p 0 inz(70)
//     D J               s              3p 1 inz(0.6)
//     D K               s              2p 0 inz(25)
//     D L               s              2p 1 dim(3)
//     D V               s              5p 2
//     D W               s              5p 1 
//     D X               s              8p 4
//     D Y               s              6p 2
//     D Z               s              5p 3
//      *
//     C     ADDTEST       BEGSR     
//      *
//      /FREE
//          L(1) = 1.0;
//          L(2) = 1.7;
//          L(3) = -1.1;

//          A = A + 1;                // A = 002
//          V = B + C;                // V = 042.00
//          V = B + D;                // V = 0
//          V = C;                    // V = 032.00
//          E = E - 1;                // E = 005
//          W = C - B;                // W = 0022.0
//          W = C - D;                // W = 0042.0
//          W = -C;                   // W = -0032.0
//          F = F * E;                // F = 060
//          X = B * G;                // X = 0027.7000
//          X = B * D;                // X = -0100.0000
//          H = H / B;                // H = 007
//          Y = C / J;                // Y = 0053.33
//          eval(r) Z = % sqrt(K);    // Z = 05.000
//          Z = % xfoot(L);           // Z = 01.600 

//          dump(a);
//          *inlr = *on;
//      / END - FREE
//      *
//     C *
//     C * In the following example, the initial field values are:
//     C*
//     C*                         A = 1
//     C*                         B = 10.0
//     C*                         C = 32
//     C*                         D = -20
//     C*                         E = 6
//     C*                         F = 10.0
//     C*                         G = 2.77
//     C*                         H = 70
//     C*                         J = .6
//     C*                         K = 25
//     C*                         L = 1.0, 1.7, -1.1                              Result:
//     C*
//      *
//     C                   ADD       1             A                 3 0          A = 002
//     C     B             ADD       C             V                 5 2          V = 042.00
//     C     B             ADD       D             V                              V = -10.00
//     C                   Z-ADD     C             V                              V = 032.00
//     C                   SUB       1             E                 3 0          E = 005
//     C     C             SUB       B             W                 5 1          W = 0022.0
//     C     C             SUB       D             W                              W = 0052.0
//     C                   Z-SUB     C             W                              W = -0032.0
//     C                   MULT      E             F                 3 0          F = 060
//     C     B             MULT      G             X                 8 4          X = 0027.7000
//     C     B             MULT      D             X                              X = -0200.0000
//     C                   DIV       B             H                 3 0          H = 007
//     C     C             DIV       J             Y                 6 2          Y = 0053.33
//     C                   MVR                     Z                 5 3          Z = 00.002
//     C                   SQRT      K             Z                              Z = 05.000
//     C                   XFOOT     L             Z                              Z = 01.600
//      * 
//     C                   ENDSR	 

using Extensions;
using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Add : IFixedFormat
    {
        [Length(3), Decimals(0)] public decimal A = 1;
        [Length(3), Decimals(1)] public decimal B = 10.0M;
        [Length(3), Decimals(1)] public decimal C = 32.0M;
        [Length(2), Decimals(0)] public decimal D = -10;
        [Length(3), Decimals(0)] public decimal E = 6;
        [Length(3), Decimals(0)] public decimal F = 10;
        [Length(5), Decimals(2)] public decimal G = 2.77M;
        [Length(3), Decimals(0)] public decimal H = 70;
        [Length(3), Decimals(1)] public decimal J = 0.6M;
        [Length(2), Decimals(0)] public decimal K = 25;
        [Length(5), Decimals(3)] public decimal[] L = new decimal[3];
        [Length(5), Decimals(2)] public decimal V;
        [Length(5), Decimals(1)] public decimal W = 1;
        [Length(8), Decimals(4)] public decimal X = 1;
        [Length(6), Decimals(2)] public decimal Y = 1;
        [Length(5), Decimals(3)] public decimal Z = 1;

        public void AddTest()
        {
            L[0] = 1.0M;
            L[1] = 1.7M;
            L[2] = -1.1M;

            A++;                                    // A = 002
            V = B + C;                              // V = 042.00d
            V = B + D;                              // V = 0
            V = C;                                  // V = 032.00
            E--;                                    // E = 005
            W = C - B;                              // W = 0022.0
            W = C - D;                              // W = 0042.0
            W = -C;                                 // W = -0032.0
            F *= E;                                 // F = 050 
            X = B * G;                              // X = 0027.7000
            X = B * D;                              // X = -0100.0000
            H /= B;                                 // H = 007
            Y = C / J;                              // Y = 0053.33
            Z = (decimal)Math.Sqrt((double)K);      // Z = 05.000
            Z = L.Sum();                            // Z = 01.600 

            Console.WriteLine();
            Console.WriteLine(" ----------------------------");
            Console.WriteLine(" AddTest");
            Console.WriteLine(" ----------------------------");

            Console.WriteLine($" A:{A.Fixed("A")}");
            Console.WriteLine($" V:{V.Fixed("V")}");
            Console.WriteLine($" E:{E.Fixed("E")}");
            Console.WriteLine($" W:{W.Fixed("W")}");            
            Console.WriteLine($" F:{F.Fixed("F")}");            
            Console.WriteLine($" X:{X.Fixed("X")}");
            Console.WriteLine($" H:{H.Fixed("H")}");
            Console.WriteLine($" Y:{Y.Fixed("Y")}");
            Console.WriteLine($" Z:{Z.Fixed("Z")}");
        }

        public void TruncationTest_Failure()
        {
            Console.WriteLine();
            Console.WriteLine(" ----------------------------");
            Console.WriteLine(" Truncation Example - Fails");
            Console.WriteLine(" ----------------------------");

            // If W is a 6-character decimal - 123456
            // If A is a 3-character demical - 000
            // The, moving W to A should truncate 3 characters. Which 3 should remain and which 3 should truncate?
            W = 123456;
            A = 0;
            A = W;
            Console.WriteLine($" W:{W.Fixed("W")}");
            Console.WriteLine($" A:{A.Fixed("A")}");
        }

        public void TruncationTest_Success()
        {
            Console.WriteLine();
            Console.WriteLine(" ----------------------------");
            Console.WriteLine(" Truncation Example - Success");
            Console.WriteLine(" ----------------------------");
            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine(" Move larger var (W) to smaller var (A)");
            Console.WriteLine(" ---------------------------------------");

            W = 123456;
            A = 000;

            // Here I'm having to pass in the variable names to pull the length
            // attribute. It would be nice if we didn't have to pass them but
            // could determine them in the Move method. But I don't see how.
            //
            // The problem is that once A and W are passed into the function,
            // they are no longer called A and W, but now are the parameter 
            // variable names. There seems like we could pass them by ref or some
            // way to get back to the original variable name. We need the 
            // origional name to pull the length and decimal positions from
            // the symbol table. The idea that would be able to just do A.Move(W)
            // if we didn't have this issue. But since we do, we have to tell
            // the Move function which variable names to pull from the 
            // SymbolTable.

            A = A.Move(W, "A", "W");

            Console.WriteLine($" W:{W.Fixed("W")}");            
            Console.WriteLine($" A:{A.Fixed("A")}");

            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine(" Move smaller var (A) to larger var (W)");
            Console.WriteLine(" ---------------------------------------");

            A = 555;
            W = W.Move(A, "W", "A");
            var test = W.Format("W");

            Console.WriteLine($" A:{A.Fixed("A")}");
            Console.WriteLine($" W:{W.Fixed("W")}");

        }

    }

}

