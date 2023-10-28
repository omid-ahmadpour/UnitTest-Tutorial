using System.Text.RegularExpressions;

namespace UnitTestTutorial.Persistence.Validtors
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Use a regular expression to validate the email format
            // This is a basic example and doesn't cover all possible cases
            return Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*$");
        }
    }
}
