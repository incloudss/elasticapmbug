using System.Reflection;
using DownstreamService;
using Elastic.Apm.AspNetCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenTelemetry()
    .WithTracing(x =>
    {
        x.ConfigureResource(y => y.AddService(Assembly.GetEntryAssembly().GetName().Name));
        x.AddAspNetCoreInstrumentation(opt => opt.RecordException = true);
        x.AddHttpClientInstrumentation();
        x.AddSqlClientInstrumentation(y => y.SetDbStatementForText = true);
        x.AddOtlpExporter(y =>
        {
            y.Endpoint = new Uri("http://localhost:4317");
        });
        x.AddConsoleExporter();
    });

builder.Services.AddHttpClient<ITestClient, TestClient>();

var app = builder.Build();
app.UseElasticApm(app.Configuration);
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
