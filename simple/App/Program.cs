using System;
using System.IO;
using Simple.Models;
using Microsoft.AspNetCore.Hosting;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();    
        }
    }
}
