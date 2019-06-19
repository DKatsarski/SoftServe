using System;
using System.Collections.Generic;
using Crossword.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Crossword.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void IWordsIsPopulatingDictionariesWithWordsCorrectlyWithTheGetWordsMethod()
        {
            var fakeDictionary = new Mock<IWords>();

            fakeDictionary.Setup(x => x.GetWords).Returns(new List<string>()
            {
                "asdf",
                "fdsfsd",
                "ddd"
            });

            StringAssert.Contains("ddd", fakeDictionary.Object.GetWords[2]);
        }

        [TestMethod]
        public void CheckIfTheNumberOfAddedWordsCorrespondsToTheActualGetMethodReturns()
        {
            var fakeDictionary = new Mock<IWords>();

            fakeDictionary.Setup(x => x.GetWords).Returns(new List<string>()
            {
                "asdf",
                "fdsfsd",
                "ddd"
            });

            Assert.AreEqual(3, fakeDictionary.Object.GetWords.Count);
        }
    }
}
