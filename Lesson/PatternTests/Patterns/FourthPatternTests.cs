using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class FourthPatternTests
    {
        [TestMethod]
        public void CreateFourthStar()
        {
            // Arrange
            var validResult = new PatternResultModel("    *****\n   *****\n  *****\n *****\n*****\n", TextAlignment.Left);
            var pattern = new FourthPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateFourthStar_InputMinus()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.NegativeNum);
            var pattern = new FourthPattern();

            // Act
            var result = pattern.Create(-1);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateFourthStar_TooHigh()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.TooHighNum);
            var pattern = new FourthPattern();

            // Act
            var result = pattern.Create(100000);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

    }
}