using System;
using System.Windows;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternTests.Patterns
{
    [TestClass]
    public class SeventhPatternTests
    {
        [TestMethod]
        public void CreateSeventhStar()
        {
            // Arrange
            var validResult = new PatternResultModel(
                "*     *      *       *        *         \n      **     **      **       **        \n             ***     ***      ***       \n                     ****     ****      \n                              *****     \n"
                , TextAlignment.Left, 25, new SeventhPattern());
            var pattern = new SeventhPattern();

            // Act
            var result = pattern.Create(5);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod]
        public void CreateFoldedOutputTest()
        {
            // Arrange
            var validResult =
                "*     *      *                   *                        \n      **     **                  **                       \n             ***     .  .  .     ***                      \n                                 ****                     \n                                 *****                    \n                                 ******                   \n                                 *******                  \n                                 ********                 \n                                 *********                \n                                 **********               \n                                 ***********              \n                                 ************             \n                                 *************            \n                                 **************           \n                                 ***************          \n                                 ****************         \n                                 *****************        \n                                 ******************       \n                                 *******************      \n                                 ********************     \n";
            var pattern = new SeventhPattern();

            // Act
            var result = pattern.CreateFoldedOutput(pattern.Create(20).Output);

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자에 음수는 허용되지 않습니다.")]
        public void CreateStar_InputMinus()
        {
            // Act
            var result = new FifthPattern().Create(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "입력 숫자가 너무 큽니다.")]
        public void CreateStar_TooHigh()
        {
            var result = new FifthPattern().Create(100000);
        }
    }
}