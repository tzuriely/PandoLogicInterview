using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandoLogic.Application.Queries;
using PandoLogic.Application.Queries.Responses;
using PandoLogic.Application.Services;
using PandoLogic.Domain;

namespace PandoLogic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsServices _services;

        public JobsController(IJobsServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{from}/{to}")]
        public async Task<ActionResult<IList<Day>>> Get(string from, string to)
        {
            var query = new GetJobsQuery() { From = from, To = to };
            var jobs = await _services.Handle(query);
            return Ok(jobs);
        }

        [HttpGet]
        [Route("range")]
        public async Task<ActionResult<DatesRangeQueryResponse>> Get()
        {
            var query = new DatesRangeQuery();
            var range = await _services.Handle(query);

            return range;
        }
    }
}