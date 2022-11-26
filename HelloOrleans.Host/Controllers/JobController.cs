using HelloOrleans.Host.Contract.Entity;
using HelloOrleans.Host.Contract.Grain;
using HelloOrleans.Host.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace HelloOrleans.Host.Controllers
{
    [Route("job")]
    public class JobController : Controller
    {
        private IGrainFactory _factory;

        public JobController(IGrainFactory grainFactory)
        {
            _factory = grainFactory;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateJobViewModel model)
        {
            var jobId = Guid.NewGuid().ToString();
            var jobGrain = _factory.GetGrain<IJobGrain>(jobId);

            var job = new Job()
            {
                Title = model.Title,
                Description = model.Description,
                Location = model.Location,
            };
            job = await jobGrain.Create(job);
            return Ok(job);
        }

        [Route("{jobId}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(string jobId)
        {
            if (string.IsNullOrEmpty(jobId))
            {
                throw new ArgumentNullException(nameof(jobId));
            }

            var jobGrain = _factory.GetGrain<IJobGrain>(jobId);
            return Ok(await jobGrain.Get());
        }
    }
}
