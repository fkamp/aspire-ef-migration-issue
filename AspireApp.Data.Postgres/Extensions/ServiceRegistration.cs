using AspireApp.Common.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspireApp.Data.Postgres.Extensions;
public static class ServiceRegistration
{

    public static IHostApplicationBuilder AddPostgresInfrastructure(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        //ef core
        builder.AddNpgsqlDbContext<ApplicationDbContext>("employee-db");

        services.AddScoped<IEmployeeRepo, EmployeeRepo>();

        //dapper
        builder.AddNpgsqlDataSource("employee-db");
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();


        return builder;
    }
}
