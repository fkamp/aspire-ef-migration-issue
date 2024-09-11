# Aspire EF Core Migration Issue

Here is how you can replicate the issue.

1. Run ef migration

```powershell
cd .\AspireApp\AspireApp.ApiService
dotnet ef migrations add update -p ..\AspireApp.Data.Postgres\
```

2. This will fail with 

```
Unable to create a 'DbContext' of type ''. The exception 'ConnectionString is missing. It should be provided in 'ConnectionStrings:employee-db' or under the 'ConnectionString' key in 'Aspire:Npgsql' configuration section.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```

3. When changing the following lines in file
`AspireApp.Data.Postgres.Extensions.ServiceRegistration` the EF Migration will go through without any issue.

```csharp
//builder.AddNpgsqlDataSource(ServiceNames.DATABASE_EMPLS.NAME);
//services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

services.AddScoped<ISqlConnectionFactory>(x => new MockSqlConnectionFactory());
```



Am I doing something wrong or is this a bug?
