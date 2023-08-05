using Serilog;

namespace WorldCup.Infrastructure.Logging
{
    internal class SerilogLogger : Application.Interfaces.Logging.ILogger
    {
        private static readonly ILogger _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

        public SerilogLogger() { }

        public Task LogException(string template, params object[] props)
        {
            _logger.Error(template, props);

            return Task.CompletedTask;
        }

        public Task LogException(Exception exception, string template, params object[] props)
        {
            _logger.Error(exception, template, props);

            return Task.CompletedTask;
        }
    }
}
