using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class SeventhPatternTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var pattern = new SeventhPattern();
            const string validResult = "*     *      *       *        *         \n      **     **      **       **        \n             ***     ***      ***       \n                     ****     ****      \n                              *****     \n";

            // Act
            pattern.Create(5);

            // Assert
            Assert.AreEqual(pattern.Result, validResult);
        }

        [TestMethod()]
        public void CreateFoldedOutputTest()
        {
            // Arrange
            var pattern = new SeventhPattern();
            const string validResult = "*     *      *                   *                   \n      **     **                  **                  \n             ***     .  .  .     ***                 \n                                 ****                \n                                 *****               \n                                 ******              \n                                 *******             \n                                 ********            \n                                 *********           \n                                 **********          \n                                 ***********         \n                                 ************        \n                                 *************       \n                                 **************      \n                                 ***************     \n";

            // Act
            pattern.Create(15);
            pattern.CreateFoldedOutput();
            // Assert
            Assert.AreEqual(pattern.FoldedResult, validResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest_ArgException()
        {
            // Arrange
            var pattern = new SeventhPattern();

            // Assert
            pattern.Create(999999);
        }
    }
}