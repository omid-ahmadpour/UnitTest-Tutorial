namespace UnitTestTutorial.Persistence.Tests
{
    public class BestPracticeExamples
    {
        //// 1. Arrange Tests for Readability

        //[Test]
        //public void CalculateTotal_WhenCalled_ReturnsCorrectSum()
        //{
        //    // Arrange
        //    var order = new Order();
        //    order.AddItem(10);
        //    order.AddItem(15);

        //    // Act
        //    var total = order.CalculateTotal();

        //    // Assert
        //    Assert.AreEqual(25, total);
        //}

        //var mockService = new Mock<IExternalService>();
        //mockService.Setup(s => s.GetData()).Returns("Mocked Data");

        //// Inject mock into the class under test
        //var myClass = new MyClass(mockService.Object);


        //// 2. Testing Edge Cases

        //[Test]
        //public void CalculateTotal_WhenNoItems_ReturnsZero()
        //{
        //    // Arrange
        //    var order = new Order();

        //    // Act
        //    var total = order.CalculateTotal();

        //    // Assert
        //    Assert.AreEqual(0, total);
        //}


        //// 3. Dependency Management

        //[Test]
        //public void CalculateTotal_WhenItems_ReturnsValue()
        //{
        //    var mockService = new Mock<IExternalService>();
        //    mockService.Setup(s => s.GetData()).Returns("Mocked Data");

        //    // Inject mock into the class under test
        //    var myClass = new MyClass(mockService.Object);
        //}

    }
}
