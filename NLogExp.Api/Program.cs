
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLogExp.ServiceDefaults;

namespace NLogExp.Api;

public class Program
{
    public static void Main(string[] args)
    {

        ConfigureNlog();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.AddServiceDefaults();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    public static void ConfigureNlog()
    {
        ConsoleTarget consoleTarget = new()
        {
            Name = "consoleTarget",
            Layout = "${message}"
        };
        //LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
        //loggingConfiguration.AddRuleForAllLevels(consoleTarget);
        //LogFactory logFactory = new LogFactory(loggingConfiguration);
        LogFactory logFactory = new ();
        Logger psLogger =logFactory.GetLogger("logconsole");
        psLogger.Debug("Logging from nlog");


    }
}
