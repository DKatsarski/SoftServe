using Crossword.Constants;
using Crossword.Operators;
using System;
using System.Collections.Generic;

namespace Crossword.Generators
{
    public class CrosswordGenerator
    {
        private string[,] crossword;
        private List<string> listOfAllWords;
        private WordsOperator wordsOperator;
        private RandomGenerator randomGenerator;
        private ArrayOperator arrayOperator;
        private WordsVerificator wordVerificator;
        private MatrixWriter matrixWriter;
        private Painter painter;

        public CrosswordGenerator(string[,] crossword, WordsOperator wordsOperator)
        {
            this.crossword = crossword;
            this.wordsOperator = wordsOperator;
            this.listOfAllWords = wordsOperator.ListOfAllWords;
            this.randomGenerator = new RandomGenerator();
            this.arrayOperator = new ArrayOperator();
            this.wordVerificator = new WordsVerificator();
            this.painter = new Painter();
            this.matrixWriter = new MatrixWriter(wordsOperator);
        }

        public void GenerateFrame()
        {
            var randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);

            for (int i = 0; i < crossword.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    crossword[i, 0] = randomWord[i].ToString();
                }
            }

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

            var newListFromBeginning = new List<string>();
            newListFromBeginning = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(randomWord[0].ToString());
            randomWord = randomGenerator.GenerateRandomWord(newListFromBeginning);

         
            for (int i = 0; i < crossword.GetLength(1); i++)
            {
                if (i < randomWord.Length)
                {
                    crossword[0, i] = randomWord[i].ToString();
                }
            }

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);
        }

        public void GenerateCrossword()
        {
            var colFromMatrix = string.Empty;
            var rowFromMatrix = string.Empty;
            var listFromSpecificPattern = new List<string>();
            var frameOfAPotentialWord = string.Empty;
            var colOutsideRange = 1;
            var indexCounter = 0;
            var adaptatedIndex = 0;
            var randomWord = string.Empty;

            for (int row = 1; row < crossword.GetLength(0); row++)
            {
                for (int col = colOutsideRange; col < crossword.GetLength(1); col++)
                {
                    colFromMatrix = arrayOperator.ExtractColFromMatrix(crossword, col);
                    frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(colFromMatrix);

                    if (frameOfAPotentialWord == string.Empty)
                    {
                        break;
                    }

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

                        adaptatedIndex = indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                        wordsOperator.CollectedWordsFromCrossword.Add(randomWord);


                        crossword = matrixWriter.WriteOnCol(crossword, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(crossword, col, adaptatedIndex);

                        break;
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

                        adaptatedIndex = indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                        wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

                        crossword = matrixWriter.WriteOnCol(crossword, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(crossword, col, adaptatedIndex);

                        break;
                    }
                }

                //row begins here
                frameOfAPotentialWord = string.Empty;
                rowFromMatrix = arrayOperator.ExtractRowFromMatrix(crossword, row);
                frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(rowFromMatrix);
                indexCounter = 0;

                if (frameOfAPotentialWord == string.Empty)
                {
                    break;
                }

                //fillerOfMatrix
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
                            continue;
                        }
                    }

                    adaptatedIndex = indexCounter;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                    wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

                    crossword = matrixWriter.WriteOnRow(crossword, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(crossword, row, adaptatedIndex);

                    continue;
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
                            throw new FormatException("No such word exists in the given database.");
                        }
                    }

                    adaptatedIndex = indexCounter;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                    wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

                    crossword = matrixWriter.WriteOnRow(crossword, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(crossword, row, adaptatedIndex);
                    

                    continue;
                }
            }
            painter.ListAllTheWords(wordsOperator);
            Console.ReadLine();
            Console.Clear();
            painter.PaintMatrixWithSymbol(crossword, '2');
            painter.ListAllTheWords(wordsOperator);
            Console.ReadLine();
        }
    }
}
