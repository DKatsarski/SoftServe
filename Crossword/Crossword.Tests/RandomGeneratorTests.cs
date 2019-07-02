using Crossword.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Crossword.Tests
{
    [TestClass]
    public class RandomGeneratorTests
    {
        [TestMethod]
        public void GenerateRandomWordReturnsRandomWord()
        {
            var fakeGenerator = new RandomGenerator();
            var verificator = false;
            var counter = 0;
            var listOfWords = new List<string>()
            {
                "firstWord",
                "secondWord",
                "thirdWord"
            };

            var word = fakeGenerator.GenerateRandomWord(listOfWords);
            var constantVariable = listOfWords[0];

            for (int i = 0; i < 400; i++)
            {

                if (word == constantVariable)
                {
                    counter++;
                    word = string.Empty;
                }
                if (counter == 2)
                {
                    verificator = true;
                    break;
                }

                word = fakeGenerator.GenerateRandomWord(listOfWords);
            }

            Assert.IsTrue(verificator);
        }
    }
}
