using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PandoLogic.Domain;

namespace PandoLogic.Application
{
    public interface IJobsRepository
    {
        Task<IList<Day>> GetJobs(DateTime from, DateTime to);
        Task<DateTime> GetFirstDate();
        Task<DateTime> GetLastDate();

    }
}