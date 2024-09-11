# Aspire EF Core Migration Issue

Run ef migration
´´´
cd .\AspireApp\AspireApp.ApiService
dotnet ef migrations add update -p ..\AspireApp.Data.Postgres\
´´´

This will fail with 
´´´
Unable to create a 'DbContext' of type ''. The exception 'ConnectionString is missing. It should be provided in 'ConnectionStrings:employee-db' or under the 'ConnectionString' key in 'Aspire:Npgsql' configuration section.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
´´´

When commenting out the following two lines in project AspireApp.Data.Postgres, file 
AspireApp.Data.Postgres.Extensions.ServiceRegistration
´´´
builder.AddNpgsqlDataSource("employee-db");
services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
´´´

Then it will go through without any issue.

Am I doing something wrong or is this a bug?
