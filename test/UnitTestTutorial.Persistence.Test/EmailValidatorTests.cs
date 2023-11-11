using NUnit.Framework;
using UnitTestTutorial.Persistence.Validtors;

namespace UnitTestTutorial.Persistence.Tests.CleanTemplate.Persistence.Tests
{
    public class EmailValidatorTests
    {
        [Test]
        public void When_EmailIsNUll_Should_ReturnsFalse()
        {
            // Arrange
            var validator = new EmailValidator();
            string email = null;

            // Act
            var result = validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var validator = new EmailValidator();
            string email = "user@gmail.com";

            // Act
            var result = validator.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidEmail_WhiteSpaceEmail_ReturnsFalse()
        {
            // Arrange
            var validator = new EmailValidator();
            string email = " ";

            // Act
            var result = validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            var validator = new EmailValidator();
            string email = string.Empty;

            // Act
            var result = validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
