using System.Collections.Generic;
using System.Threading.Tasks;
using PandoLogic.Application.Queries;
using PandoLogic.Application.Queries.Responses;
using PandoLogic.Domain;

namespace PandoLogic.Application.Services
{
    public interface IJobsServices
    {
        Task<IList<Day>> Handle(GetJobsQuery query);
        Task<DatesRangeQueryResponse> Handle(DatesRangeQuery query);
    }
}