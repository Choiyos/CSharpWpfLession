using System;
using LessonLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternTests;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class PatternTests
    {

        #region 패턴 생성 성공 테스트

        [TestMethod()]
        public void CreateValidTest_FirstPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 1");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_SecondPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 2");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_ThirdPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 3");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_FourthPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 4");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_FifthPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 5");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_SixthPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 6");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void CreateValidTest_SeventhPattern()
        {
            // Arrange
            var validResult = PatternResult.Success;

            // Act
            Pattern.Instance.ChangePattern("Pattern 7");
            var result = Pattern.Instance.Create("5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        #endregion

        #region 패턴 생성 실패 테스트

        [TestMethod()]
        public void CreateInvalidTest_InputString()
        {
            // Arrange
            var invalidResult = PatternResult.InvalidValue;

            // Act
            var result = Pattern.Instance.Create("asdf");

            // Assert
            Assert.AreEqual(invalidResult, result);
        }

        [TestMethod()]
        public void CreateInvalidTest_OutOfNum()
        {
            // Arrange
            var invalidResult = PatternResult.InvalidValue;

            // Act
            var result = Pattern.Instance.Create("123");

            // Assert
            Assert.AreEqual(invalidResult, result);
        }

        [TestMethod()]
        public void CreateInvalidTest_InputEven()
        {
            // Arrange
            Pattern.Instance.ChangePattern("Pattern 3");
            var invalidResult = PatternResult.Pattern3Even;

            // Act
            var result = Pattern.Instance.Create("4");

            // Assert
            Assert.AreEqual(invalidResult, result);
        }

        #endregion

        #region 패턴 변경 성공 테스트

        [TestMethod()]
        public void ChangePatternTest_First()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 1");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Second()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 2");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Third()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 3");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Fourth()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 4");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Fifth()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 5");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Sixth()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 6");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ChangePatternTest_Seventh()
        {
            // Arrange
            var validResult = true;

            // Act
            var result = Pattern.Instance.ChangePattern("Pattern 7");

            // Assert
            Assert.AreEqual(validResult, result);
        }

        #endregion

        #region 패턴 변경 실패 테스트

        [TestMethod()]
        [ExpectedException(typeof(NotFiniteNumberException))]
        public void ChangePatternTest_NoPatternNum()
        {
            // Act
            Pattern.Instance.ChangePattern("Pattern WPF");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangePatternTest_OutOfPatternNum()
        {
            // Act
            Pattern.Instance.ChangePattern("Pattern 999");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePatternTest_SingleBlock()
        {
            // Act
            Pattern.Instance.ChangePattern("Pattern");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangePatternTest_InputEmpty()
        {
            // Act
            Pattern.Instance.ChangePattern("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangePatternTest_InputNull()
        {
            // Act
            Pattern.Instance.ChangePattern(null);
        }

        #endregion

        #region 기록 가져오기 테스트

        [TestMethod()]
        public void GetResultTest()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n**\n***\n****\n*****\n", TextAlignment.Left);

            // Act
            Pattern.Instance.ChangePattern("Pattern 1");
            Pattern.Instance.Create("1");
            Pattern.Instance.Create("5");
            var result = Pattern.Instance.GetResult(1);

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetResultTest_OutOfIndex_TooBig()
        {
            Pattern.Instance.GetResult(999);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetResultTest_OutOfIndex_Negative()
        {
            Pattern.Instance.GetResult(-1);
        }

        [TestMethod()]
        public void GetNextResultTest()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n**\n***\n****\n*****\n", TextAlignment.Left);

            // Act
            Pattern.Instance.ChangePattern("Pattern 1");
            Pattern.Instance.Create("5");
            Pattern.Instance.Create("1");
            var result = Pattern.Instance.GetNextResult();

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        [TestMethod()]
        public void GetPreviousResultTest()
        {
            // Arrange
            var validResult = new PatternResultModel("*\n**\n***\n****\n*****\n", TextAlignment.Left);

            // Act
            Pattern.Instance.ChangePattern("Pattern 1");
            Pattern.Instance.Create("1");
            Pattern.Instance.Create("5");
            Pattern.Instance.GetNextResult();
            var result = Pattern.Instance.GetPreviousResult();

            // Assert
            PatternAssert.ArePatternResultEqual(validResult, result);
        }

        #endregion

        #region 결과 요약 테스트

        [TestMethod()]
        public void FoldOutputTest_FoldedResult()
        {
            // Arrange
            var validResult_접힌결과 =
                "*     *      *                   *                        \n      **     **                  **                       \n             ***     .  .  .     ***                      \n                                 ****                     \n                                 *****                    \n                                 ******                   \n                                 *******                  \n                                 ********                 \n                                 *********                \n                                 **********               \n                                 ***********              \n                                 ************             \n                                 *************            \n                                 **************           \n                                 ***************          \n                                 ****************         \n                                 *****************        \n                                 ******************       \n                                 *******************      \n                                 ********************     \n";
            var pattern = new SeventhPattern();

            // Act
            Pattern.Instance.FoldOutput(pattern.Create(20));
            var result = Pattern.Instance.FoldedOutput;

            // Assert
            Assert.AreEqual(validResult_접힌결과, result);
        }

        [TestMethod()]
        public void FoldOutputTest_UnfoldedResult()
        {
            // Arrange
            var validResult_안접힌결과 =
                "*     *      *       *        *         *          *           *            *             *              *               *                *                 *                  *                   *                    *                     *                      *                       *                        \n      **     **      **       **        **         **          **           **            **             **              **               **                **                 **                  **                   **                    **                     **                      **                       \n             ***     ***      ***       ***        ***         ***          ***           ***            ***             ***              ***               ***                ***                 ***                  ***                   ***                    ***                     ***                      \n                     ****     ****      ****       ****        ****         ****          ****           ****            ****             ****              ****               ****                ****                 ****                  ****                   ****                    ****                     \n                              *****     *****      *****       *****        *****         *****          *****           *****            *****             *****              *****               *****                *****                 *****                  *****                   *****                    \n                                        ******     ******      ******       ******        ******         ******          ******           ******            ******             ******              ******               ******                ******                 ******                  ******                   \n                                                   *******     *******      *******       *******        *******         *******          *******           *******            *******             *******              *******               *******                *******                 *******                  \n                                                               ********     ********      ********       ********        ********         ********          ********           ********            ********             ********              ********               ********                ********                 \n                                                                            *********     *********      *********       *********        *********         *********          *********           *********            *********             *********              *********               *********                \n                                                                                          **********     **********      **********       **********        **********         **********          **********           **********            **********             **********              **********               \n                                                                                                         ***********     ***********      ***********       ***********        ***********         ***********          ***********           ***********            ***********             ***********              \n                                                                                                                         ************     ************      ************       ************        ************         ************          ************           ************            ************             \n                                                                                                                                          *************     *************      *************       *************        *************         *************          *************           *************            \n                                                                                                                                                            **************     **************      **************       **************        **************         **************          **************           \n                                                                                                                                                                               ***************     ***************      ***************       ***************        ***************         ***************          \n                                                                                                                                                                                                   ****************     ****************      ****************       ****************        ****************         \n                                                                                                                                                                                                                        *****************     *****************      *****************       *****************        \n                                                                                                                                                                                                                                              ******************     ******************      ******************       \n                                                                                                                                                                                                                                                                     *******************     *******************      \n                                                                                                                                                                                                                                                                                             ********************     \n";
            var pattern = new SeventhPattern();

            // Act
            Pattern.Instance.FoldOutput(pattern.Create(20));
            var result = Pattern.Instance.UnfoldedOutput;

            // Assert
            Assert.AreEqual(validResult_안접힌결과, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FoldOutputTest_Null()
        {
            // Act
            Pattern.Instance.FoldOutput(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FoldOutputTest_OutputNull()
        {
            // Act
            Pattern.Instance.FoldOutput(new PatternResultModel("", PatternResult.InvalidValue));
        }

        #endregion
    }
}