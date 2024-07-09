using Microsoft.AspNetCore.Mvc;
using NLog;
using NLogExp.Api;

namespace NLogExp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{

    private Logger _logger;
    public LogController(ILogger<LogController> logger)
    {
        LogFactory logFactory = new();
        _logger= logFactory.GetLogger("logconsole");
        var cl0 = NLog.GlobalDiagnosticsContext.Get("customLevel");
        NLog.GlobalDiagnosticsContext.Set("customLevel", "Info");
        var cl1=NLog.GlobalDiagnosticsContext.Get("customLevel");
    }

    [HttpGet("Debug")]
    public void Debug(int i=1) => _logger.Debug(i.ToString());

    [HttpGet("Info")]
    public void Info(int i=2)
    {
        _logger.Info(i.ToString());
    }
}
