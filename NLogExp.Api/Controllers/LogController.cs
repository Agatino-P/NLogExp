using Microsoft.AspNetCore.Mvc;
using NLog;
using NLogExp.Api;

namespace NLogExp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{

    
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        this._logger = logger;
    }

    [HttpGet("Debug")]
    public void Debug(int i = 1)
    {
        //_logger.Debug(i.ToString());
    }

    [HttpGet("Info")]
    public void Info(int i=2)
    {
        //_logger.Info(i.ToString());
    }

    [HttpGet("Error")]
    public void Error(int i = 3)
    {
        Person p1 = new("F", "L");
        
        _logger.LogError("Exp: {@Person}", p1);
    }


    
}

public record Person(string First, string Last);
