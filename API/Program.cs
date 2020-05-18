using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();

           using (var scope = host.Services.CreateScope())
           {
               var service_also_known_as_container = scope.ServiceProvider;
              

               try
               {
                   var dbContext = service_also_known_as_container.GetRequiredService<ReactivitiesContext>();
                   dbContext.Database.Migrate();
               }
               catch (DatabaseNotFoundException e)
               {
                   var logger = service_also_known_as_container.GetRequiredService<ILogger<Program>>();
                   logger.LogError(e, "A DatabaseNotFoundException has occured during migration");
               }
           }

           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class DatabaseNotFoundException : Exception
    {
        public DatabaseNotFoundException()
        {
            
        }

        public DatabaseNotFoundException(string message) : base(message)
        {
            
        }

        public DatabaseNotFoundException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
