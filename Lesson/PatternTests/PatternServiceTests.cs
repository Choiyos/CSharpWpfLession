using Microsoft.VisualStudio.TestTools.UnitTesting;
using LessonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonLibrary.Interface;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class PatternServiceTests
    {
        //[TestMethod]
        //public void TEST()
        //{
        //    PatternService service = new PatternService();
        //    service.Create("3");
        //    service.ChangePattern("Pattern 1");
        //    service.CanHistoryMoveNext();
        //    service.CanHistoryMovePrevious();

        //}

        [TestMethod]
        public void Test()
        {
            IPattern  i = new FirstPattern();

            Call(i);

        }

        private void Call(IPattern pattern)
        {
            Assert.IsInstanceOfType(pattern,typeof(SeventhPattern));
            Assert.IsInstanceOfType(pattern,typeof(IFoldable));
        }

        [TestMethod()]
        public void PatternServiceTest()
        {
            // Arrange
            var service = new PatternService();

            // Act

            // Assert
            Assert.IsInstanceOfType(service, typeof(PatternService));
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChangePatternTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanHistoryMoveNextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CanHistoryMovePreviousTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChangeMoveValueTest()
        {
            Assert.Fail();
        }
    }
}