namespace Crossword
{
    public static class Counter
    {
        private static int counterOfTries;

      

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
