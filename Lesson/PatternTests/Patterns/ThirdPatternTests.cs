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
            var validResult = new PatternResultModel("", TextAlignment.Center);
            var pattern = new ThirdPattern();

            // Act
            var result = pattern.Create(4);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }
    }
}