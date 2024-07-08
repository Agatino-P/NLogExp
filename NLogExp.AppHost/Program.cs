using Projects;

namespace NLogExp.AppHost;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        builder.AddProject<Projects.NLogExp_Api>("api")
             .WithExternalHttpEndpoints();
        builder.Build().Run();
    }
}