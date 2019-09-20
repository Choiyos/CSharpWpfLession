using LessonLibrary.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class NavigationHistoryTests
    {
        [TestMethod]
        public void InitTest()
        {
            // Arrange
            var navi = NaviInit();

            // Act

            // Assert
            Assert.IsNotNull(navi);
            Assert.IsInstanceOfType(navi, typeof(NavigationHistory));
        }

        [TestMethod]
        public void CapacityTest()
        {
            // Arrange
            var navi = NaviInit();

            // Act

            // Assert
            Assert.IsNotNull(navi);
            Assert.IsInstanceOfType(navi, typeof(NavigationHistory));

            Assert.AreEqual(navi.Capacity, 100);
        }

        [TestMethod]
        public void PushTest()
        {
            // Arrange
            var navi = NaviInit();

            // Act
            navi.PushPattern(new FirstPattern());

            // Assert
            Assert.AreEqual(navi.Count, 1);
        }

        [TestMethod]
        public void PushTest_Max()
        {
            // Arrange
            var navi = new NavigationHistory(3);

            // Act
            for (int i = 0; i < navi.Capacity+1; i++)
            {
                navi.PushPattern(new FirstPattern());
            }

            // Assert
            Assert.AreEqual(navi.Count, 3);
        }
        
        [TestMethod()]
        public void GetPatternsTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());

            // Act
            List<IPattern> list = navi.GetPatterns();

            // Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count,1);
        }

        [TestMethod()]
        public void ReplacePatternTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());

            // Act
            navi.ReplacePattern(new SecondPattern(), 0);

            // Assert
            Assert.IsInstanceOfType(navi.GetCurrentPattern(), typeof(SecondPattern));
        }

        [TestMethod()]
        public void GetCurrentPatternTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());

            // Act

            // Assert
            Assert.AreEqual(navi.GetCurrentPattern().ToString(),typeof(FirstPattern).ToString());
            Assert.IsInstanceOfType(navi.GetCurrentPattern(),typeof(FirstPattern));
        }

        [TestMethod()]
        public void GetNextPatternTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());
            navi.PushPattern(new SecondPattern());
            navi.PushPattern(new ThirdPattern());

            // Act
            var next = navi.GetNextPattern();

            // Assert
            Assert.IsInstanceOfType(next, typeof(SecondPattern));
        }

        [TestMethod()]
        public void GetPreviousPatternTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());
            navi.PushPattern(new SecondPattern());
            navi.PushPattern(new ThirdPattern());
            navi.GetNextPattern();

            // Act
            var previous= navi.GetPreviousPattern();

            // Assert
            Assert.IsInstanceOfType(previous, typeof(ThirdPattern));
        }

        [TestMethod()]
        public void GetPatternTest()
        {
            // Arrange
            var navi = NaviInit();
            navi.PushPattern(new FirstPattern());
            navi.PushPattern(new SecondPattern());
            navi.PushPattern(new ThirdPattern());

            // Act
            var pattern= navi.GetPattern(1);

            // Assert
            Assert.IsInstanceOfType(pattern, typeof(SecondPattern));
        }
        private static NavigationHistory NaviInit()
        {
            return new NavigationHistory(100);
        }
    }
}