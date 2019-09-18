using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class SecondPatternTests
    {
        [TestMethod]
        public void CreateSecondStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*****\n****\n***\n**\n*\n", TextAlignment.Right);
            var pattern = new SecondPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }
    }
}