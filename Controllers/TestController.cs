using Microsoft.AspNetCore.Mvc;

namespace stockapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "docke1r new", "dockerBracing", "dockerChilly", "dockerCool", "dockerMild", "Warm", "Balmy", "Hot", "Sweltering", "Test"
    };

    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
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
