using AspireApp.Common;
using AspireApp.Common.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspireApp.Data.Postgres.Extensions;
public static class ServiceRegistration
{

    public static IHostApplicationBuilder AddPostgresInfrastructure(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        //ef core
        builder.AddNpgsqlDbContext<ApplicationDbContext>(ServiceNames.DATABASE_EMPLS.NAME);

        services.AddScoped<IEmployeeRepo, EmployeeRepo>();


        //for dapper
        //*************************************************************************************
        /*

        ef migration 
            cd AspireApp.ApiService
            dotnet ef migrations add init -p ..\AspireApp.Data.Postgres\
        wont work with following two lines
        */
        builder.AddNpgsqlDataSource(ServiceNames.DATABASE_EMPLS.NAME);
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        //use this instead; allows ef migration to work and app to start
        //actual query that uses this factory wont work.
        //services.AddScoped<ISqlConnectionFactory>(x => new MockSqlConnectionFactory());
        //*************************************************************************************


        return builder;
    }
}
