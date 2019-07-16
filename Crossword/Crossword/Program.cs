using Crossword.Constants;
using Crossword.Data;
using Crossword.Generators;
using Crossword.Operators;

namespace Crossword
{
    public class Program
    {
        static void Main()
        {
            IWords englishDictionary = new EnglishWordsDictionary();
            var wordsOperator = new WordsOperator(englishDictionary);
            var randomGenerator = new RandomGenerator();
            var painter = new Painter();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            //string[,] crossword = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];
            //var crosswordGenerator = new CrosswordGenerator(crossword, wordsOperator);
            //crosswordGenerator.GenerateFrame();
            //painter.PaintMatrix(crossword, 0, 0);
            //crosswordGenerator.GenerateCrossword();


            var wordsExplorerFieldGenerator = new WordsExplorerFieldGenerator();

            var wordsExplorerField = wordsExplorerFieldGenerator.GenerateField(englishDictionary.GetAplphabet);



        }
    }
}
