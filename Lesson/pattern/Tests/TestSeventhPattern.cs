using System.Windows;
using LessonLibrary.Model;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonLibrary.Tests
{
    [TestClass]
    public class TestSeventhPattern
    {
        [TestMethod]
        public void CreateSeventhStar()
        {
            // Arrange
            var validResult = new PatternResultModel("*     *      *       *        *         \n      **     **      **       **        \n             ***     ***      ***       \n                     ****     ****      \n                              *****     \n"
                , TextAlignment.Left,25,new SeventhPattern());
            var pattern = new SeventhPattern();

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
            var validResult =
                "*     *      *                   *                        \n      **     **                  **                       \n             ***     .  .  .     ***                      \n                                 ****                     \n                                 *****                    \n                                 ******                   \n                                 *******                  \n                                 ********                 \n                                 *********                \n                                 **********               \n                                 ***********              \n                                 ************             \n                                 *************            \n                                 **************           \n                                 ***************          \n                                 ****************         \n                                 *****************        \n                                 ******************       \n                                 *******************      \n                                 ********************     \n";
            var pattern = new SeventhPattern();

            // Act
            var result = pattern.CreateFoldedOutput(pattern.Create(20).Output);

            // Assert
            Assert.AreEqual(validResult, result);
        }
    }
}
