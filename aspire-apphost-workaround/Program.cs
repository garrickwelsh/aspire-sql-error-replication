
using aspire_apphost;

var builder = DistributedApplication.CreateBuilder(args);

var databaseServer = builder.AddSqlServer(Constants.DatabaseResource, port: 14333)
  .WithContainerName(Constants.ContainerName)
  .WithLifetime(ContainerLifetime.Session);

var database = databaseServer.AddDatabase(Constants.Database);
var errorDatabaseProject = builder.AddSqlProject(Constants.DatabaseDefinition)
  .WithDacpac("../sql/bin/aspire-error.dacpac")
  .WithReference(database);

builder.Build().Run();
