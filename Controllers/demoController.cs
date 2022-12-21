using Microsoft.AspNetCore.Mvc;

namespace stockapi.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "demo new", "demo", "demo", "demo", "dockerMild", "demoWarm", "demoBalmy", "Hot", "Sweltering", "Test"
    };

    private readonly ILogger<TestController> _logger;

    public DemoController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "TestForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
