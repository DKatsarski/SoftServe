using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Data;
using Crossword.Operators;
using System.Text.RegularExpressions;
using Crossword.Constants;

namespace Crossword
{
    class Program
    {
        static void Main()
        {
            IWords englishDictionary = new EnglishWordsDictionary();
            var wordsOperator = new WordsOperator(englishDictionary);
            var arrayOperator = new ArrayOperator();
            var randomGenerator = new RandomGenerator();
            var wordVerificator = new WordsVerificator();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            var randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);


            string[] englishAlphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[40, 40];

            var list = new List<string>()
            {
                "bojo",
                "tonkata",
                "paloma"
            };


            var listtt = new List<string>();

            listtt = wordsOperator.GetListOfAllWordsFromASpecifiedPattern("c...s.");

            //it should "StartsWith" Substring of the specific caracters in the crossword
            Console.WriteLine(wordVerificator.ContainsWordWithSpecificBeginning(list, "p"));


            //logic for the existance of the word as a whole
            Console.WriteLine(wordVerificator.IsWordInList(list, "tonkta"));
            string a = @"b";

            Console.WriteLine(wordVerificator.ContainsWordWithSpecificPositionOfCharacters(list, a));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(Regex.Match(list[i], a));
            }

            //Console.WriteLine(list.Exists(() => Regex.Match(a));

            string asdf = "aato";
            string fdfd = "...";
            string ff = "sdf....df....";

            Console.WriteLine(asdf);

            while (!wordVerificator.ContainsWordWithSpecificBeginning(list, asdf))
            {
                if (asdf.Length > 1)
                {
                    asdf = asdf.Substring(1);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(asdf);






         
            //var asdfasdf = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning("do");
            //var a = 3;

            //while (randomWord.Substring(0, 2) != "do")
            //{

            //        randomWord = asdfasdf[a];


            //    a++;
            //}
            //Console.WriteLine(randomWord);





            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[i, 0] = randomWord[i].ToString();
                }
            }

            randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);

            while (testArray[0, 0] != randomWord[0].ToString())
            {
                randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);

            }

            for (int i = 0; i < testArray.GetLength(1); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[0, i] = randomWord[i].ToString();
                }
            }

            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 1; col < testArray.GetLength(1); col++)
                {

                }
            }

            var randomLetter = string.Empty;
            var colFromMatrix = string.Empty;
            var rowFromMatrix = string.Empty;
            var listFromSpecificPattern = new List<string>();

            var frameOfAPotentialWord = string.Empty;
            var colOutsideRange = 0;
            var indexCounter = 0;

            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 1; col < testArray.GetLength(1); col++)
                {
                    //TODO: Stop, when the coloumns are as the generated random word
                    colFromMatrix = arrayOperator.ExtractColFromMatrix(testArray, row, col);

                    //Than find word
                    //than write word

                    //!!!!!!!!if it is string.Empty than it should stop 
                    frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(colFromMatrix);

                    //TODO: Extracting random word and than writing it in the matrix
                    if (!frameOfAPotentialWord.Contains(GlobalConstants.SpecificSymbolToReplaceNull))
                    {
                        while (!wordVerificator.ContainsWordWithSpecificBeginning(listOfAllWords, frameOfAPotentialWord))
                        {
                            if (frameOfAPotentialWord.Length > 1)
                            {
                                frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                                indexCounter++;
                            }
                            else
                            {
                                break;
                            }

                        }

                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);

                    }
                    else
                    {
                        while (!wordVerificator.ContainsWordWithSpecificPositionOfCharacters(listOfAllWords, frameOfAPotentialWord))
                        {

                            if (frameOfAPotentialWord.Length > 1)
                            {
                                frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                                indexCounter++;
                            }
                            else
                            {
                                break;
                            }
                        }
                   
                    }

                    indexCounter = 0;

                    colOutsideRange = col;

                    //TODO: check if there is a words with such begininng - if not - change the begininng and the position 


                }
                frameOfAPotentialWord = string.Empty;
                rowFromMatrix = arrayOperator.ExtractRowFromMatrix(testArray, row, colOutsideRange);
                frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(rowFromMatrix);
            }


            //drawing
            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    Console.Write("{0} ",
                    testArray[row, col]);
                }
                Console.WriteLine();
            }

            //TODO: The logic should start from the first column, than from the frist row. It should check if there is a word from that string, than from row -> if there is word from that string. If there is not, than from the next substring

        }


    }
}
