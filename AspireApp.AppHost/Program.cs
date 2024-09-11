using AspireApp.Common;

var builder = DistributedApplication.CreateBuilder(args);


var postgres = builder.AddPostgres(ServiceNames.DATABASE_EMPLS.SERVERNAME)
    .WithDataVolume()
    .WithPgAdmin();
var postgresdb = postgres.AddDatabase(ServiceNames.DATABASE_EMPLS.NAME);


builder.AddProject<Projects.AspireApp_ApiService>("apiservice")
    .WithReference(postgresdb);


builder.AddProject<Projects.AspireApp_Service_DatabaseMigration>("aspireapp-service-databasemigration")
    .WithReference(postgresdb);

builder.Build().Run();
