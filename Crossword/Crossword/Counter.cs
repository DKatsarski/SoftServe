using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public static class Counter
    {
        private static int counterOfTries = -1;

      

        public static void  CounterOfWrongAnswers()
        {
            counterOfTries++;
        }

        public static int ReturnWrongAnswers()
        {
            return counterOfTries;
        }
    }
}
