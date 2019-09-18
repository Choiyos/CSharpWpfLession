using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class ThirdPatternTests
    {
        [TestMethod]
        public void CreateThirdOddStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n***\n*****\n***\n*\n", TextAlignment.Center);
            var pattern = new ThirdPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod]
        public void CreateThirdEvenStar()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.Pattern3Even);
            var pattern = new ThirdPattern();

            // Act
            var result = pattern.Create(4);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateThirdStar_InputMinus()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.NegativeNum);
            var pattern = new ThirdPattern();

            // Act
            var result = pattern.Create(-1);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateThirdStar_TooHigh()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.TooHighNum);
            var pattern = new ThirdPattern();

            // Act
            var result = pattern.Create(100000);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

    }
}