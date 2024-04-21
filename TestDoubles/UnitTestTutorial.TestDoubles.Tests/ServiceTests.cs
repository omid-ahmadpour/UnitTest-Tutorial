namespace UnitTestTutorial.TestDoubles.Tests
{
    public class ServiceTests
    {
        // Fake Example
        [Test]
        public void Save_SavesDataToFakeDatabase()
        {
            // Arrange
            var fakeDatabase = new FakeDatabase();
            var data = "Sample data";
            var service = new Service(fakeDatabase);

            // Act
            service.SaveData(data);

            // Assert
            Assert.Contains(data, fakeDatabase.GetAllData());
        }
    }
}
