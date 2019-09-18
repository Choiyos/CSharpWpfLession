using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class SeventhPatternTests
    {
        [TestMethod]
        public void CreateSeventhStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*     *      *       *        *         \n      **     **      **       **        \n             ***     ***      ***       \n                     ****     ****      \n                              *****     \n"
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

        [TestMethod()]
        public void CreateSeventhStar_InputMinus()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.NegativeNum);
            var pattern = new SeventhPattern();

            // Act
            var result = pattern.Create(-1);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateSeventhStar_TooHigh()
        {
            // Arrange
            var validResult = new PatternResultModel("", PatternResult.TooHighNum);
            var pattern = new SeventhPattern();

            // Act
            var result = pattern.Create(100000);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

    }
}