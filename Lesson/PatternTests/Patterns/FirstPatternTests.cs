using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class FirstPatternTests
    {
        [TestMethod()]
        public void CreateFirstStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n**\n***\n****\n*****\n", TextAlignment.Left);
            var pattern = new FirstPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }
    }
}