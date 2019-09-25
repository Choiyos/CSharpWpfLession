using Lesson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class PatternSelectorTests
    {

        [TestMethod()]
        public void SelectPatternTest()
        {
            // Arrange
            var pattern = PatternSelector.SelectPattern(MainWindow.ParsePattern("Pattern 1"));
            
            // Act

            // Assert
            Assert.IsInstanceOfType(pattern,typeof(FirstPattern));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void SelectPatternTest_invalid()
        {
            // Assert
            PatternSelector.SelectPattern(MainWindow.ParsePattern("Pattern 999"));
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SelectPatternTest_OutOfRange()
        {
            // Assert
            PatternSelector.SelectPattern(MainWindow.ParsePattern("Pattern_TEST"));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SelectPatternTest_invalid_Argue()
        {
            // Assert
            PatternSelector.SelectPattern(MainWindow.ParsePattern("Pattern TEST"));
        }
    }
}