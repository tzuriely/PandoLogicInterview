using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PandoLogic.Domain;

namespace PandoLogic.Infrastructure.Data
{
    public class PandoLogicContextSeed
    {
        public static async Task AddAsync(PandoLogicContext context, ILogger<PandoLogicContextSeed> logger)
        {
            await context.Database.EnsureCreatedAsync();
            if (!context.Dates.Any())
            {
                await context.AddRangeAsync(GetPreconfiguredJobs());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(PandoLogicContextSeed).Name);
            }
        }

        private static IEnumerable<Day> GetPreconfiguredJobs()
        {
            return new List<Day>()
            {
                new Day()
                {
                    Date = DateTime.ParseExact("01/01/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 44, TotalViews = 24, ActiveJobs = 34
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/02/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 50, TotalViews = 35, ActiveJobs = 49 
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/03/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 55, TotalViews = 42, ActiveJobs = 78
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/04/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 60, TotalViews = 47, ActiveJobs = 84
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/05/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 74, TotalViews = 52, ActiveJobs = 90
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/06/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 80, TotalViews = 56, ActiveJobs = 95
                },
                new Day()
                {
                    Date = DateTime.ParseExact("01/07/2021", "MM/dd/yyyy", CultureInfo.InstalledUICulture), CumulativePredicted = 89, TotalViews = 59, ActiveJobs = 100
                },


            };
        }
    }
}