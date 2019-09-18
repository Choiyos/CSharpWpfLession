using System.Windows;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonLibrary.Tests
{
    [TestClass()]
    public class TestFirstPattern
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
            Assert.AreEqual(validResult.Output, result.Output);
            Assert.AreEqual(validResult.TextAlignment, result.TextAlignment);
            Assert.AreEqual(validResult.Pattern, result.Pattern);
            Assert.AreEqual(validResult.Lines, result.Lines);
        }
    }
}
