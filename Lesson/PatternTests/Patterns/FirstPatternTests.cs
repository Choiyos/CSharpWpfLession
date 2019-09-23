using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class FirstPatternTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var pattern = new FirstPattern();

            // Act
            pattern.Create(5);

            // Assert
            Assert.AreEqual(pattern.Result, "*\n**\n***\n****\n*****\n");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_ArgException()
        {
            // Arrange
            var pattern = new FirstPattern();

            // Assert
            pattern.Create(999999);
        }

    }
}