using AspireApp.Common;
using AspireApp.Data.Postgres;
using AspireApp.Service.DatabaseMigration;
using AspireApp.ServiceDefaults;
using Microsoft.EntityFrameworkCore;


var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString(ServiceNames.DATABASE_EMPLS.NAME))
);

builder.Services.AddOpenTelemetry()
        .WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

var host = builder.Build();
host.Run();