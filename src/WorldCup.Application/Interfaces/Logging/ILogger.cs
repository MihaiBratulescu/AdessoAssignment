namespace WorldCup.Application.Interfaces.Logging
{
    public interface ILogger
    {
        Task LogException(string template, params object[] props);
        Task LogException(Exception exception, string template, params object[] props);
    }
}
