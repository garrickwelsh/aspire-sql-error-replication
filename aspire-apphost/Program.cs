
using aspire_apphost;

var builder = DistributedApplication.CreateBuilder(args);

var databaseServer = builder.AddSqlServer(Constants.DatabaseResource, port: 14333)
  .WithContainerName(Constants.ContainerName)
  .WithLifetime(ContainerLifetime.Session);

var database = databaseServer.AddDatabase(Constants.Database);
var errorDatabaseProject = builder.AddSqlProject<Projects.aspire_error>(Constants.DatabaseDefinition)
  .WithReference(database);

builder.Build().Run();
