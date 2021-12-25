using MessageService.Job;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace MessageService.Controllers
{
    public class JobController : Controller
    {
        private readonly QuartzHostedService _service;
        public JobController(QuartzHostedService service)
        {
            _service = service;
        }
        public async void StartJob()
        {
            await _service.StartAsync(new CancellationToken());
        }
        public async void StopJob()
        {
            await _service.StopAsync(new CancellationToken());
        }
    }
}
