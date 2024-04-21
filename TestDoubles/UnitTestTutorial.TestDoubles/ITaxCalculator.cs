namespace UnitTestTutorial.TestDoubles
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal income);
    }

    public class Calculator
    {
        private readonly ITaxCalculator _taxCalculator;

        public Calculator(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal GetTotalSalaryAfterTax(decimal income)
        {
            var tax = _taxCalculator.CalculateTax(income);
            return income - tax;
        }
    }
}
