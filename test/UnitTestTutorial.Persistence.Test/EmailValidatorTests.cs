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
    }
}
