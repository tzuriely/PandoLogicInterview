using System;
using Microsoft.EntityFrameworkCore;
using PandoLogic.Domain;

namespace PandoLogic.Infrastructure.Data
{
    public class PandoLogicContext : DbContext
    {
        public PandoLogicContext(DbContextOptions<PandoLogicContext> options) : base(options)
        {
            
        }

        public DbSet<Day> Dates { get; set; }
        //public DbSet<Job> Jobs { get; set; }
    }
}