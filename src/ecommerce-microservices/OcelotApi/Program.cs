using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json")
    .AddEnvironmentVariables();

var services = builder.Services;

services.AddOcelot(builder.Configuration);

var app = builder.Build();

await app.UseOcelot();

app.Run();