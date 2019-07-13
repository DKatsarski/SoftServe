using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public static class Counter
    {
        private static int counterOfTries;

        public static int CountTries()
        {
            counterOfTries++;
            return counterOfTries;
        }
    }
}
