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

            // Act
            pattern.Create(5);

            // Assert
            Assert.AreEqual(pattern.Result, "*     *      *       *        *         \n      **     **      **       **        \n             ***     ***      ***       \n                     ****     ****      \n                              *****     \n");
        }

        [TestMethod()]
        public void CreateFoldedOutputTest()
        {
            // Arrange
            var pattern = new SeventhPattern();

            // Act
            pattern.Create(15);
            pattern.CreateFoldedOutput();
            // Assert
            Assert.AreEqual(pattern.FoldedResult, "*     *      *                   *                   \n      **     **                  **                  \n             ***     .  .  .     ***                 \n                                 ****                \n                                 *****               \n                                 ******              \n                                 *******             \n                                 ********            \n                                 *********           \n                                 **********          \n                                 ***********         \n                                 ************        \n                                 *************       \n                                 **************      \n                                 ***************     \n");
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