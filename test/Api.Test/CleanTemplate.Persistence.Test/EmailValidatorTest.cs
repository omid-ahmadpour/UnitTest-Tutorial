using NUnit.Framework;
using UnitTestTutorial.Persistence.Validtors;

namespace CleanTemplate.Persistence.Test
{
    public class EmailValidatorTest
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
