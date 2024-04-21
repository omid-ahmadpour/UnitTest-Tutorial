namespace UnitTestTutorial.TestDoubles
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogError(string errorMessage)
        {
            _logger.Log($"Error: {errorMessage}");
        }
    }
}
