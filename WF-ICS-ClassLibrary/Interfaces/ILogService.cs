namespace WildfireICSDesktopServices.Logging
{
    public interface ILogService
    {
        string GetLogPath();
        void Log(string message);
    }
}