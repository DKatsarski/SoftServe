using System;
using System.Collections.Generic;
using Crossword.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Crossword;
using Crossword.Contracts;
using Crossword.Operators;
using Crossword.Constants;

namespace Crossword.Tests.OperatorsTests
{
    [TestClass]
    public class ArrayOperatorTests
    {
        [TestMethod]
        public void ExtactColFromMatrixMethodReturnsCorrectString()
        {
            var arrOperator = new Mock<IArrayOperator>();

            var fakeMatrix = new string[4, 4];
            var testResult = arrOperator.Setup(x => x.ExtractColFromMatrix(fakeMatrix, 3)).Returns("a##e");

            string expectedString = "a##e";
            StringAssert.Equals(expectedString, testResult);
        }

        [TestMethod]
        public void ExtactColFromMatrixMethodReturnsCorrectStringFromSpecificMatrix()
        {
            var arrOperator = new Mock<IArrayOperator>();
            var randomGen = new RandomGenerator();
            var colOfAMatrix = string.Empty;
            var fakeAlphabet = new string[]
            {
                "a", "b", "#"
            };

            var fakeMatrix = new string[10, 7];

            for (int i = 0; i < fakeMatrix.GetLength(0); i++)
            {
                for (int col = 0; col < fakeMatrix.GetLength(1); col++)
                {
                    fakeMatrix[i, col] = randomGen.GenerateRandomLetter(fakeAlphabet);
                }
            }

            for (int i = 0; i < fakeMatrix.GetLength(1); i++)
            {
                colOfAMatrix += fakeMatrix[i, 3];
            }

            var stringToCompare = arrOperator.Object.ExtractColFromMatrix(fakeMatrix, 3);

            StringAssert.Equals(colOfAMatrix, stringToCompare);
        }

        [TestMethod]
        public void ExtactColFromMatrixMethodReturnsSpecificSymbolInsteadOfNull()
        {
            var arrOperator = new ArrayOperator();
            var randomGen = new RandomGenerator();

            var fakeAlphabet = new string[]
            {
                 null, null, null, null, null, null, "a"
            };

            var fakeMatrix = new string[10, 7];


            for (int i = 0; i < fakeMatrix.GetLength(0); i++)
            {
                for (int col = 0; col < fakeMatrix.GetLength(1); col++)
                {
                    fakeMatrix[i, col] = randomGen.GenerateRandomLetter(fakeAlphabet);
                }
            }

            var stringToCompare = arrOperator.ExtractColFromMatrix(fakeMatrix, 3);

            StringAssert.Contains(stringToCompare, GlobalConstants.SpecificSymbolToReplaceNull);
        }

        [TestMethod]
        public void ExtactColFromMatrixMethodReturnsSpecificSymbolInsteadOfNullOnSpecificPosition()
        {
            var arrOperator = new ArrayOperator();
            var randomGen = new RandomGenerator();

            var fakeAlphabet = new string[]
            {
                 null, null, null, null, null, null, "a"
            };

            var fakeMatrix = new string[5, 5];

            fakeMatrix[0, 0] = "a";
            fakeMatrix[1, 0] = "b";
            fakeMatrix[2, 0] = null;
            fakeMatrix[3, 0] = null;
            fakeMatrix[4, 0] = "a";


            var counter = 0;


            var stringToCompare = arrOperator.ExtractColFromMatrix(fakeMatrix, 0);

            for (int i = 0; i < stringToCompare.Length; i++)
            {
                if (stringToCompare[i].ToString() == GlobalConstants.SpecificSymbolToReplaceNull)
                {
                    counter++;
                }
            }
            Assert.AreEqual(2, counter);
        }
    }
}
