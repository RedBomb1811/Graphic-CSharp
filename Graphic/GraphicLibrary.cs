using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic
{
    class Screen
    {
        readonly int resolution_X;
        readonly int resolution_Y;
        byte[,] screenArray;
        readonly int[] density = new int[7] {
                0x2588,
                0x2593,
                0x2592,
                0x2591,
                0x2219, // центральная точка
                0x00B7,  // центральный кубик
                0x00A0
            };

        // 0x0387 маленькая центральная точка

        public int Resolution_X { get => resolution_X; }
        public int Resolution_Y { get => resolution_Y; }
        public byte[,] ScreenArray { get => screenArray; set => screenArray = value; }
        public int[] Density => density;

        public byte this[int i, int j]
        {
            get => ScreenArray[i, j];
            set => ScreenArray[i, j] = value;
        }

        public Screen(int x, int y)
        {
            resolution_X = x;
            resolution_Y = y;
            ScreenArray = new byte[Resolution_Y, Resolution_X];
            for (int i = 0; i < Resolution_Y; i++)
                for (int j = 0; j < Resolution_X; j++)
                    ScreenArray[i, j] = 0;

            Console.SetWindowSize(Resolution_X, Resolution_Y);
            Console.SetBufferSize(Resolution_X, Resolution_Y);
            Console.Title = "Screen";
        }

        public void RedrawScreen_2()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Resolution_Y; i++)
            {
                for (int j = 0; j < Resolution_X; j++)
                {
                    switch (this[i, j])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write((char)0x2219);
                }
            }
        }

        public void ChangeColor(ConsoleColor color ) {
            Console.ForegroundColor = color;
        }

        public void RedrawScreen()
        {
            Console.SetCursorPosition(0, 0);
            string str = "";
            for (int i = 0; i < Resolution_Y; i++)
            {
                for (int j = 0; j < Resolution_X; j++)
                {
                    str += (char)Density[ScreenArray[i, j]];
        //            str += (char)density[(int)(i * Density.Length / Resolution_Y)];
                }
            }
            Console.Write(str);
        }

        public void FillScreen(byte a)
        {
            for (int i = 0; i < Resolution_Y; i++)
            {
                for (int j = 0; j < Resolution_X; j++)
                {
                    ScreenArray[i, j] = a;
                }
            }
        }

        public void DrawFromEquation(Func<int, int, int> function, int c, byte a)
        {
        //    for (int y = 0; y < Resolution_Y; y++)
            for (int x = 0; x < Resolution_X; x++)
            {
                if(function(x, c) >= 0 && function(x, c) < Resolution_Y)
                    ScreenArray[function(x, c), x] = a;
            }
        }

        public void WriteSymbol(char sym, int x, int y)
        {
            byte[,] arrsym;
            switch (sym)
            {
                case '0':
                    arrsym = new byte[,] { 
                        { 0, 0, 1, 1, 0, 0 }, 
                        { 0, 1, 0, 0, 1, 0 }, 
                        { 1, 0, 0, 0, 0, 1 }, 
                        { 1, 0, 0, 0, 0, 1 }, 
                        { 1, 0, 0, 0, 0, 1 }, 
                        { 1, 0, 0, 0, 0, 1 }, 
                        { 0, 1, 0, 0, 1, 0 }, 
                        { 0, 0, 1, 1, 0, 0 }
                    };
                    break;
                case '1':
                    arrsym = new byte[,] {
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 1, 1 }
                    };
                    break;
                case '2':
                    arrsym = new byte[,] {
                        { 0,  0,  1,  1,  0,  0 },
                        { 0,  1,  0,  0,  1,  0 },
                        { 1,  0,  0,  0,  0,  1 },
                        { 0,  0,  0,  0,  0,  1 },
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  1,  1,  0,  0 },
                        { 0,  1,  0,  0,  0,  0 },
                        { 1,  1,  1,  1,  1,  1 }
                    };
                    break;
                case '3':
                    arrsym = new byte[,] {
                        { 1,  1,  1,  1,  1,  1 },
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  0,  1,  0,  0 },
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  0,  0,  0,  1 },
                        { 1,  0,  0,  0,  0,  1 },
                        { 0,  1,  0,  0,  1,  0 },
                        { 0,  0,  1,  1,  0,  0 }
                    };
                    break;
                case '4':
                    arrsym = new byte[,] {
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  0,  1,  1,  0 },
                        { 0,  0,  1,  0,  1,  0 },
                        { 0,  1,  0,  0,  1,  0 },
                        { 1,  0,  0,  0,  1,  0 },
                        { 1,  1,  1,  1,  1,  1 },
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  0,  0,  1,  0 }
                    };
                    break;
                case '5':
                    arrsym = new byte[,] {
                        { 1,  1,  1,  1,  1,  1 },
                        { 1,  0,  0,  0,  0,  0 },
                        { 1,  1,  1,  1,  0,  0 },
                        { 0,  0,  0,  0,  1,  0 },
                        { 0,  0,  0,  0,  0,  1 },
                        { 1,  0,  0,  0,  0,  1 },
                        { 0,  1,  0,  0,  1,  0 },
                        { 0,  0,  1,  1,  0,  0 }
                    };
                    break;
                case '6':
                    arrsym = new byte[,] {
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 1, 1 }
                    };
                    break;
                case '7':
                    arrsym = new byte[,] {
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 1, 1 }
                    };
                    break;
                case '8':
                    arrsym = new byte[,] {
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 1, 1 }
                    };
                    break;
                case '9':
                    arrsym = new byte[,] {
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 0, 0, 1, 1, 0, 0 },
                        { 1, 1, 1, 1, 1, 1 }
                    };
                    break;
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2, byte color)
        {
            int X1 = Math.Min(x1, x2);
            int X2 = Math.Max(x2, x1);
            for (int x = 0; x < Resolution_X; x++) {
                int Y = (x * (y2 - y1) + (X2 * y1 - X1 * y2)) / (X2 - X1);
                if(Y >= 0 && Y < Resolution_Y)
                    ScreenArray[Y, x] = color;
            }
        }

        public void DrawLineSegment(int x1, int y1, int x2, int y2, byte color)
        {
            int X1 = Math.Min(x1, x2);
            int X2 = Math.Max(x2, x1);
            for (int x = X1; x <= X2; x++)
            {
                int Y = (x * (y2 - y1) + (X2 * y1 - X1 * y2)) / (X2 - X1);
                if (Y >= 0 && Y < Resolution_Y && x >= 0 && x < Resolution_X)
                    ScreenArray[Y, x] = color;
            }
        }

        public void DrawPoint(int x, int y, byte color)
        {
            if (x >= 0 && x < Resolution_X && y >= 0 && y < Resolution_Y)
                ScreenArray[y, x] = color;
        }
    }
}
