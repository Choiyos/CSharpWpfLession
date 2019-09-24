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
            service.ChangePattern("Pattern 1");
            var validResult = new FirstPattern();
            validResult.Create(3);

            // Act
            var pattern = service.Create(3,false);

            // Assert
            Assert.IsInstanceOfType(pattern, typeof(FirstPattern));
            Assert.AreEqual(pattern.Result, validResult.Result);
        }

        [TestMethod()]
        public void ChangePatternTest1()
        {
            // Arrange
            var service = new PatternService();
            const string validResult = "Pattern 1";

            // Act
            service.ChangePattern("Pattern 1");

            // Assert
            Assert.AreEqual(service.CurrentPattern, validResult);

        }

        [TestMethod()]
        public void CreateRandomTest()
        {
            // Arrange
            var service = new PatternService();
            service.ChangePattern("Pattern 6");

            // Act
            var pattern = service.Create(5, true);

            // Assert
            Assert.IsNotNull(pattern);
            Assert.IsInstanceOfType(pattern,typeof(IRandomable));
        }

        [TestMethod()]
        public void CreateRandomTest_랜덤함수없는_패턴인데_랜덤호출()
        {
            // Arrange
            var service = new PatternService();
            service.ChangePattern("Pattern 1");

            // Act
            var pattern = service.Create(5, true);

            // Assert
            Assert.IsNull(pattern);
        }
    }
}