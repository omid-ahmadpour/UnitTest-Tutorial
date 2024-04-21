using Moq;

namespace UnitTestTutorial.TestDoubles.Tests
{
    using NUnit.Framework;

    // Mock Example
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void GetUserNameById_ReturnsUserName_WhenUserExists()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserById(1)).Returns(new User { Name = "John" });
            var userService = new UserService(userRepositoryMock.Object);

            // Act
            var result = userService.GetUserNameById(1);

            // Assert
            Assert.AreEqual("John", result);
        }
    }
}
