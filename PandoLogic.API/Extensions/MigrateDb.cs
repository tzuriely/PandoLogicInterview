using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PandoLogic.Infrastructure.Data;

namespace PandoLogic.API
{
    internal static class MigrateDb
    {
        public static IHost MigrateDatabase(this IHost host,
            Action<PandoLogicContext, IServiceProvider> seeder,
            int? retry = 0) 
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<PandoLogicContext>>();
                var context = services.GetService<PandoLogicContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(PandoLogicContext).Name);

                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(PandoLogicContext).Name);
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(PandoLogicContext).Name);

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase(host, seeder, retryForAvailability);
                    }
                }
            }
            return host;
        }

        private static void InvokeSeeder(Action<PandoLogicContext, IServiceProvider> seeder,
            PandoLogicContext context,
            IServiceProvider services)
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}