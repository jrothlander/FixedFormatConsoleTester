using Extensions;

namespace ConsoleApp1
{
    public class Move : IFixedFormat
    {
        [Length(3), Decimals(0)] public decimal A = 1;

        public void MoveTest()
        { 
        
        }
    }
}
