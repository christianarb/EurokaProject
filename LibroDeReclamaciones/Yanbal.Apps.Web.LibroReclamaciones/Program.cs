using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Netcore.Infrastructure.Crosscutting;
using Netcore.Web;

namespace Netcore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: false)
          .Build();
            ApplicationInsightsSettings app_insights_settings = new ApplicationInsightsSettings();
            config.GetSection("ApplicationInsights").Bind(app_insights_settings);
            CreateWebHostBuilder(args, app_insights_settings).Build().Run();
        }

  
        public static IWebHostBuilder CreateWebHostBuilder(string[] args, 
            ApplicationInsightsSettings app_insights_settings) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIIS()
                .UseStartup<Startup>()
                .ConfigureLogging(
                builder =>
                {
                    // Providing an instrumentation key here is required if you're using
                    // standalone package Microsoft.Extensions.Logging.ApplicationInsights
                    // or if you want to capture logs from early in the application startup
                    // pipeline from Startup.cs or Program.cs itself.
                    builder.AddApplicationInsights(app_insights_settings.InstrumentationKey);
                    // Optional: Apply filters to control what logs are sent to Application Insights.
                    // The following configures LogLevel Information or above to be sent to
                    // Application Insights for all categories.
                    builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                     ("", LogLevel.Information);
                }
            );
    }
}
