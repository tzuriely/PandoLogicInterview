using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using PandoLogic.Application.Queries;
using PandoLogic.Application.Queries.Responses;
using PandoLogic.Domain;

namespace PandoLogic.Application.Services
{
    public class JobsServices : IJobsServices
    {
        private readonly IJobsRepository _repository;

        public JobsServices(IJobsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Day>> Handle(GetJobsQuery query)
        {
            var from = DateTime.ParseExact(query.From, "yyyy-MM-dd", CultureInfo.InstalledUICulture);
            var to = DateTime.ParseExact(query.To, "yyyy-MM-dd", CultureInfo.InstalledUICulture);
            var jobs = await _repository.GetJobs(from, to);
            return jobs;
        }

        public async Task<DatesRangeQueryResponse> Handle(DatesRangeQuery query)
        {
            var response = new DatesRangeQueryResponse();
            response.StartDate = await _repository.GetFirstDate();
            response.EndDate = await _repository.GetLastDate();

            return response;
        }
    }
}