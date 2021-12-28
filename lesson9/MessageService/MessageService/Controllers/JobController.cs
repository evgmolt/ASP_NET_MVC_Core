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
        /// <summary>
        /// Запускает отправку сообщений по расписанию. 
        /// </summary>
        [HttpGet("Job/StartJob")]
        public async void StartJob()
        {
            await _service.StartAsync(new CancellationToken());
        }

        /// <summary>
        /// Останавливает отправку сообщений по расписанию. 
        /// </summary>
        [HttpGet("Job/StopJob")]
        public async void StopJob()
        {
            await _service.StopAsync(new CancellationToken());
        }
    }
}
