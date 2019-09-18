using System.Windows;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;

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
    }
}