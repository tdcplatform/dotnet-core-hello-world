using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HelloWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                          .AddCommandLine(args)
                          .Build();
            var host = new WebHostBuilder()
                        .UseKestrel(                        
                            options =>
                            {
                                options.Listen(IPAddress.Any, 8086);
                                options.Limits.MaxRequestBodySize = null;
                            }
                        )
                        .UseConfiguration(config)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        //.UseUrls("http://localhost:8086", "https://localhost:8087")
                        .Build();
            host.Run();
            
        }
    }
}
