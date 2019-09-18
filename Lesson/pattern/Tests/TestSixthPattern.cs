using System.Windows;
using System.Windows.Media.Animation;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonLibrary.Tests
{
    [TestClass]
    public class TestSixthPattern
    {
        [TestMethod]
        public void CreateSixthStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n\n*\n**\n\n*\n**\n***\n\n*\n**\n***\n****\n\n*\n**\n***\n****\n*****\n\n", TextAlignment.Left,20,new SixthPattern());
            var pattern = new SixthPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            Assert.AreEqual(validResult.Output, result.Output);
            Assert.AreEqual(validResult.TextAlignment, result.TextAlignment);
            Assert.AreEqual(validResult.Pattern.ToString(), result.Pattern.ToString());
            Assert.AreEqual(validResult.Lines, result.Lines);
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
            Assert.AreEqual(validResult,result);
        }
    }
}
