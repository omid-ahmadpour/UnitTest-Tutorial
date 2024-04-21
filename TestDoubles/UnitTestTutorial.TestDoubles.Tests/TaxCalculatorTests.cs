using Moq;

namespace UnitTestTutorial.TestDoubles.Tests
{
    public class TaxCalculatorTests
    {
        // Stub Example
        [Test]
        public void GetTotalSalaryAfterTax_ReturnsCorrectAmount_AfterTaxCalculation()
        {
            // Arrange
            var taxCalculatorStub = new Mock<ITaxCalculator>();

            // Stub for tax calculation
            taxCalculatorStub.Setup(taxCalc => taxCalc.CalculateTax(1000)).Returns(100);
            var calculator = new Calculator(taxCalculatorStub.Object);

            // Act
            var result = calculator.GetTotalSalaryAfterTax(1000);

            // Assert
            Assert.AreEqual(900, result);
        }
    }
}
