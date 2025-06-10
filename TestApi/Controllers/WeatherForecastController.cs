using Microsoft.AspNetCore.Mvc;
using TestApi.Controllers.ExceptionFilters;

namespace TestApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		[NotFoundFilter]
		public IEnumerable<WeatherForecast> Get()
		{
			var response =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();

			if (cond(true))
			{
				throw new InvalidOperationException("Entity not found");
			}

			return response;
		}

		private bool cond(bool condition)
		{
			return condition;
		}
	}
}
