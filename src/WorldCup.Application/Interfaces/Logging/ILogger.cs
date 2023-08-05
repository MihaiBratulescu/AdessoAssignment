namespace WorldCup.Application.Interfaces.Logging
{
    public interface ILogger
    {
        Task LogInfo(string message);
        Task LogException(string message);
        Task LogException(Exception exception);
        Task LogException(Exception exception, string message);
    }
}
