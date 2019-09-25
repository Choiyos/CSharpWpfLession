using System;
using Lesson;
using LessonLibrary;
using LessonLibrary.Interface;
using LessonLibrary.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternTests
{
    [TestClass()]
    public class PatternServiceTests
    {
        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            var service = new PatternService();
            var validResult = new FirstPattern();
            validResult.Create(3);

            // Act
            var pattern = service.Create(3);

            // Assert
            Assert.IsInstanceOfType(pattern, typeof(FirstPattern));
            Assert.AreEqual(pattern.Result, validResult.Result);
        }

        [TestMethod()]
        public void ChangePatternTest1()
        {
            // Arrange
            var service = new PatternService();

            // Act
            service.ChangePattern(PatternOption.Fifth);

            // Assert
            Assert.IsInstanceOfType(service.Create(5), typeof(FifthPattern));
        }

        [TestMethod()]
        public void CreateRandomTest()
        {
            // Arrange
            var service = new PatternService();
            service.ChangePattern(PatternOption.Sixth);

            // Act
            var pattern = service.Create(5);

            // Assert
            Assert.IsNotNull(pattern);
            Assert.IsInstanceOfType(pattern,typeof(IRandomable));
        }

        [TestMethod()]
        public void CreateRandomTest_랜덤함수없는_패턴인데_랜덤호출()
        {
            // Arrange
            var service = new PatternService();

            // Act
            service.ChangeRandomFlag(true);

            // Assert
            Assert.AreEqual(service.IsRandom, false);
        }

        [TestMethod()]
        public void ChangeRandomFlagTest()
        {
            // Arrange
            var service = new PatternService();

            // Act
            service.ChangePattern(PatternOption.Sixth);
            service.ChangeRandomFlag(true);

            //Assert
            Assert.AreEqual(service.IsRandom,true);
        }
    }
}