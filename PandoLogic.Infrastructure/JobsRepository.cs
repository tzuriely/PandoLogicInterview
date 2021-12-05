using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PandoLogic.Application;
using PandoLogic.Domain;
using PandoLogic.Infrastructure.Data;

namespace PandoLogic.Infrastructure
{
    public class JobsRepository : IJobsRepository
    {
        private readonly PandoLogicContext _context;

        public JobsRepository(PandoLogicContext context)
        {
            _context = context;
        }

        public async Task<DateTime> GetFirstDate()
        {
            var d = await _context.Dates
                .MinAsync(x => x.Date);

            return d.Date;
        }



        public async Task<DateTime> GetLastDate()
        {
            var d = await _context.Dates
                .MaxAsync(x => x.Date);

            return d.Date;
        }

        public async Task<IList<Day>> GetJobs(DateTime from, DateTime to)
        {
            var jobs = await _context.Dates
                .Where(x => x.Date >= from && x.Date <= to)
                .ToListAsync();

            return jobs;
        }
    }
}