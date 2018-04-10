using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic
{
    class Program
    {
        // Font-Size 5 Max: 454x141 Coordinates(-4, 0)
        // FullScreen font-size 5 Max: 453x139
        // Font-Size 6 Max: 340x119 Coordinates(-4, 0)
        // FullScreen font-size 6 Max: 339x115
        // Font-Size 8 Max: 272x87 Coordinates(-4, 0)
        // FullScreen font-size 8 Max: 
        public static int Method(int variable)
        {
            return variable * variable;
        }

        static void Main(string[] args)
        {
            Func<int, int> F  = Method;
            Screen screen = new Screen(272, 87);
            screen.ChangeColor(ConsoleColor.Green);
            screen.FillScreen(6);
            screen.DrawLine(40, 80, 100, 10, 5);
            screen.DrawLineSegment(40, 10, 10, 40, 3);
            screen.DrawLineSegment(40, 30, 60, 10, 0);
            screen.DrawPoint(40, 80, 0);
            screen.DrawPoint(100, 10, 0);
            int r = 0;
            while (r < 50)
            {
                screen.DrawLine(100 + r, 1, 101 + r, 0, 3);
                r += 2;
            }
            r = 0;
            while (r < 30)
            {
                if (!(r > 10 && r < 19))
                {
                    screen.DrawLine(51 + r, 0, 52 + r, 1, 0);
                    screen.DrawLine(50 + r, 0, 51 + r, 1, 0);
                }
                r += 2;
            }
            r = 0;
            while (r < 10)
            {
                screen.DrawLineSegment(56, 75 + r, 150, 40 + r, 6);
                r++;
            }


            screen.RedrawScreen();
            Console.ReadKey();
        }
    }
}
