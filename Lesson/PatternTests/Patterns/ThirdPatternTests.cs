﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class ThirdPatternTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var pattern = new ThirdPattern();
            const string validResult = "*\n***\n*****\n***\n*\n";

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
            var pattern = new ThirdPattern();

            // Assert
            pattern.Create(999999);
        }
    }
}