using Lesson;
using LessonLibrary.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace LessonLibrary.Patterns.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void ApplyPatternTest_Unfolded()
        {
            // Arrange
            MainWindow mainWindow = new MainWindow();
            IPattern pattern = new FirstPattern();

            // Act
            pattern.Create(5);
            mainWindow.ApplyResult(pattern);

            // Assert
            Assert.AreEqual(mainWindow.txtDisplay.Text, pattern.Result);
        }

        [TestMethod]
        public void ApplyPatternTest_Folded()
        {
            // Arrange
            MainWindow mainWindow = new MainWindow();
            SeventhPattern pattern = new SeventhPattern();

            // Act
            pattern.Create(20);
            pattern.CreateFoldedOutput();
            mainWindow.ApplyResult(pattern);

            // Assert
            Assert.AreEqual(mainWindow.txtDisplay.Text, pattern.FoldedResult);
        }

        [TestMethod]
        public void ApplyPatternTest_ButtonEnable()
        {
            // Arrange
            MainWindow mainWindow = new MainWindow();
            SeventhPattern pattern = new SeventhPattern();
            pattern.Create(50);
            pattern.CreateFoldedOutput();

            // Act
            mainWindow.ApplyResult(pattern);

            // Assert
            Assert.AreEqual(mainWindow.btnShowOrHide.Visibility, Visibility.Visible);
        }

        [TestMethod]
        public void ApplyPatternTest_ButtonDisable()
        {
            // Arrange
            MainWindow main = new MainWindow();
            SeventhPattern pattern = new SeventhPattern();
            pattern.Create(5);
            pattern.CreateFoldedOutput();

            // Act
            main.ApplyResult(pattern);

            // Assert
            Assert.AreEqual(main.btnShowOrHide.Visibility, Visibility.Hidden);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ApplyPatternTest_패턴에_NULL입력시()
        {
            // Assert
            new MainWindow().ApplyResult(null);
        }
    }
}