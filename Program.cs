using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace GraphDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("From Program, running the host now.");

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                });
            //.ConfigureLogging((context, builder) =>
            //    {
            //        builder.AddApplicationInsights(
            //            context.Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

            //        // Capture all log-level entries from Program
            //        builder.AddFilter<ApplicationInsightsLoggerProvider>(
            //            typeof(Program).FullName, LogLevel.Trace);

            //        // Capture all log-level entries from Startup
            //        builder.AddFilter<ApplicationInsightsLoggerProvider>(
            //            typeof(Startup).FullName, LogLevel.Trace);
            //    });
    }
}