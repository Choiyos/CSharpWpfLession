using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass()]
    public class PatternServiceTests
    {

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            var service= new PatternService();
            service.ChangePattern("Pattern 1");
            var validResult = new FirstPattern();
            validResult.Create(3);
            // Act
            var pattern = service.Create(3);

            // Assert
            Assert.IsInstanceOfType(pattern,typeof(FirstPattern));
            Assert.AreEqual(pattern.Result,validResult.Result);
        }

        [TestMethod()]
        public void ChangePatternTest1()
        {
            // Arrange
            var service =  new PatternService();
            var validResult = "Pattern 1";

            // Act
            service.ChangePattern("Pattern 1");

            // Assert
            Assert.AreEqual(service.CurrentPattern,validResult);

        }
    }
}