using Moq;

namespace UnitTestTutorial.TestDoubles.Tests
{
    public class LoggerTests
    {
        // Spy Example
        [Test]
        public void LogError_CallsLogMethod_WithCorrectErrorMessage()
        {
            // Arrange
            var loggerSpy = new Mock<ILogger>();
            var logger = new Logger(loggerSpy.Object);

            // Act
            logger.LogError("Something went wrong");

            // Assert
            loggerSpy.Verify(log => log.Log("Error: Something went wrong"), Times.Once);
        }
    }
}
