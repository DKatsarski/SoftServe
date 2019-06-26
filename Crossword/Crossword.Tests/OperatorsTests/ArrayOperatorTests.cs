using System;
using System.Collections.Generic;
using Crossword.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Crossword;
using Crossword.Operators.Contracts;
using Crossword.Operators;

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
            var testResult = arrOperator.Setup(x => x.ExtractColFromMatrix(fakeMatrix, 3, 3)).Returns("a##e");
            
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

            var stringToCompare = arrOperator.Object.ExtractColFromMatrix(fakeMatrix, 0, 3);

            StringAssert.Equals(colOfAMatrix, stringToCompare);
        }

        [TestMethod]
        public void ExtactColFromMatrixMethodReturnsSpecificSymbolInsteadOfNull()
        {
            var arrOperator = new ArrayOperator();
            var randomGen = new RandomGenerator();
            var colOfAMatrix = string.Empty;
            var specificSymbol = "#";

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

            var stringToCompare = arrOperator.ExtractColFromMatrix(fakeMatrix, 0, 3);

            StringAssert.Contains(stringToCompare, specificSymbol);
        }
    }
}
