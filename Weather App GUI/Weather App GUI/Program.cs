using Serilog;


namespace Weather_App_GUI
{
    internal static class Program
    {
    [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path: "logs\\myapp.txt", rollingInterval: RollingInterval.Day,
            fileSizeLimitBytes: 10_485_760,    // 10 MB size limit
            rollOnFileSizeLimit: true, retainedFileCountLimit: 7)  // Retain last 7 files
                .CreateLogger();
            ApplicationConfiguration.Initialize();
            Log.Information("Application is starting.");
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new Form1());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // Flush and close the Serilog logger
            Log.CloseAndFlush();
        }

    }
}