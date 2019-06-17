using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main()
        {
            var test = new int[10, 10];

            for (int row = 0; row < test.GetLength(0); row++)
            {
                for (int col = 0; col < test.GetLength(1); col++)
                {
                    test[row, col] = col;
                }
            }


            for (int row = 0; row < test.GetLength(0); row++)
            {
                for (int col = 0; col < test.GetLength(1); col++)
                {
                    Console.Write(test[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
