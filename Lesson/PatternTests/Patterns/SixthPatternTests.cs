﻿using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class SixthPatternTests
    {
        [TestMethod]
        public void CreateSixthStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n\n*\n**\n\n*\n**\n***\n\n*\n**\n***\n****\n\n*\n**\n***\n****\n*****\n\n", TextAlignment.Left, 20, new SixthPattern());
            var pattern = new SixthPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod]
        public void CreateFoldedOutputTest()
        {
            // Arrange
            var validResult = "*\n\n*\n**\n\n*\n**\n***\n" + "\n.\n.\n.\n" + "\n\n*\n**\n***\n****\n*****\n******\n*******\n********\n*********\n**********\n***********\n************\n*************\n**************\n***************\n****************\n*****************\n******************\n*******************\n********************\n\n";
            var pattern = new SixthPattern();

            // Act
            var result = pattern.CreateFoldedOutput(pattern.Create(20).Output);

            // Assert
            Assert.AreEqual(validResult, result);
        }
    }
}