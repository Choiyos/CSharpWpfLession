using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class SixthPatternTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var pattern = new SixthPattern();

            // Act
            pattern.Create(5);

            // Assert
            Assert.AreEqual(pattern.Result, "*\n\n*\n**\n\n*\n**\n***\n\n*\n**\n***\n****\n\n*\n**\n***\n****\n*****\n\n");
        }

        [TestMethod()]
        public void CreateFoldedOutputTest()
        {
            // Arrange
            var pattern = new SixthPattern();

            // Act
            pattern.Create(20);
            pattern.CreateFoldedOutput();

            // Assert
            Assert.AreEqual(pattern.FoldedResult, "*\n\n*\n**\n\n*\n**\n***\n\n.\n.\n.\n\n\n*\n**\n***\n****\n*****\n******\n*******\n********\n*********\n**********\n***********\n************\n*************\n**************\n***************\n****************\n*****************\n******************\n*******************\n********************\n\n");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_ArgException()
        {
            // Arrange
            var pattern = new SixthPattern();

            // Assert
            pattern.Create(99999);
        }

        [TestMethod]
        public void CreateTest_Random()
        {
            // Arrange
            var pattern = new SixthPattern();
            var randPattern = new SixthPattern();

            // Act
            pattern.Create(5);
            randPattern.CreateRandom(5);

            // Assert
            Assert.AreNotEqual(pattern.Result, randPattern.Result);
        }
    }
}