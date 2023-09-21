using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase{
    private readonly ILogger<WeatherForecastController> _logger;

    IHelloWorldService helloWorldService;

    TareasContext dbContext;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get(){
        _logger.LogDebug("Retornanto el Hello World");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}