using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class FifthPatternTests
    {
        [TestMethod()]
        public void CreateFifthStar()
        {
            // Arrange
            var validResult = new PatternResultModel("    *****\n   ****\n  ***\n **\n*\n", TextAlignment.Left);
            var pattern = new FifthPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateFifthStar_InputMinus()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.NegativeNum);
            var pattern = new FifthPattern();

            // Act
            var result = pattern.Create(-1);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateFifthStar_TooHigh()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.TooHighNum);
            var pattern = new FifthPattern();

            // Act
            var result = pattern.Create(100000);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }
    }
}