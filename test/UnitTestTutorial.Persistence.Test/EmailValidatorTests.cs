using NUnit.Framework;
using UnitTestTutorial.Persistence.Validtors;

namespace UnitTestTutorial.Persistence.Tests
{
    public class EmailValidatorTests
    {
        private EmailValidator validator;

        [SetUp]
        public void Setup()
        {
            this.validator = new EmailValidator();
        }

        [Test, Category("Basic")]
        public void When_EmailIsNUll_Should_ReturnsFalse()
        {
            // Arrange
            string email = null;

            // Act
            var result = this.validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase("user@gmail.com")]
        [TestCase("user1@gmail.com")]
        [TestCase("user2@gmail.com")]
        public void IsValidEmail_ValidEmail_ReturnsTrue(string email)
        {
            // Arrange

            // Act
            var result = this.validator.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test, Category("Advance")]
        public void IsValidEmail_WhiteSpaceEmail_ReturnsFalse()
        {
            // Arrange
            string email = " ";

            // Act
            var result = this.validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            string email = string.Empty;

            // Act
            var result = this.validator.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            // clean some resources
        }
    }
}
