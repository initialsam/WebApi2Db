using Domain;

using MDB1Repository;

using MDB2Repository;

using Microsoft.AspNetCore.Mvc;

namespace WebApi2Db.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IGenericRepository<DeeplinkLog> _deeplinkLogRepo;
        private readonly IGenericRepository2<FcmTopic> _fcmTopicLogRepo;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IGenericRepository<DeeplinkLog> deeplinkLogRepo,
            IGenericRepository2<FcmTopic> fcmTopicLogRepo,
            ILogger<WeatherForecastController> logger)
        {
            _deeplinkLogRepo = deeplinkLogRepo;
            _fcmTopicLogRepo = fcmTopicLogRepo;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            _deeplinkLogRepo.Add(new DeeplinkLog
            {
                CreateTime = DateTime.Now,
                Medium = "A1",
                OsType = "A2",
                Source = "A3",
                Topic = "A4",
            });
            await _deeplinkLogRepo.SaveAsync();
            _fcmTopicLogRepo.Add(new FcmTopic
            {
                TopicName = "BB1",
                Count = 1,
            });
            await _fcmTopicLogRepo.SaveAsync();
            var dd = _deeplinkLogRepo.Where(x=>x.SeqNo>0).FirstOrDefault();
            var ff = _fcmTopicLogRepo.Where(x=>x.SeqNo>0).FirstOrDefault();



            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = $"{dd.Medium} - {ff.TopicName}"
            })
            .ToArray();
        }
    }
}
