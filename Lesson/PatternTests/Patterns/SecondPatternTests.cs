using System;
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

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자에 음수는 허용되지 않습니다.")]
        public void CreateStar_InputMinus()
        {
            // Act
            var result = new FifthPattern().Create(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자가 너무 큽니다.")]
        public void CreateStar_TooHigh()
        {
            var result = new FifthPattern().Create(100000);
        }

    }
}