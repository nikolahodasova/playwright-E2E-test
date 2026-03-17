using Serilog;

namespace PlaywrightE2ETest.Utils
{
    public class Logger
    {
        public static void Init()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/test-log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}