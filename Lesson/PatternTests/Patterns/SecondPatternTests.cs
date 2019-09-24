using System;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternTests.Patterns
{
    [TestClass()]
    public class SecondPatternTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var pattern = new SecondPattern();
            const string validResult = "*****\n****\n***\n**\n*\n";

            // Act
            pattern.Create(5);

            // Assert
            Assert.AreEqual(pattern.Result, validResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_ArgException()
        {
            // Arrange
            var pattern = new SecondPattern();

            // Assert
            pattern.Create(999999);
        }
    }
}