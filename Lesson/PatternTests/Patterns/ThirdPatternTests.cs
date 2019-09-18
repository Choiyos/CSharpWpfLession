using System;
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
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자에 음수는 허용되지 않습니다.")]
        public void CreateStar_InputMinus()
        {
            // Act
            var result = new ThirdPattern().Create(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자가 너무 큽니다.")]
        public void CreateStar_TooHigh()
        {
            var result = new ThirdPattern().Create(100000);
        }

    }
}