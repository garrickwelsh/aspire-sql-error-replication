This project reproduces an Aspire 13 and dotnet 10 error when running integration tests with sqlproj that applies dacpacs.

The SqlProj is able to run correctly but when run from the DistributedApplicationTestingBuilder an error is raised.
A workaround is included that applies the dacpac manually.

A devcontainer has been included that contains the environment that I used to reproduce the error.

# Running - Reproduce the error.

```bash
dotnet run --project aspire-error
```

# Running - The workaround to the error.
Run the workaround for the project.
```bash
dotnet run --project aspire-error-workaround
```

# Key code (Reproducing the error)

AppHost
```csharp
var errorDatabaseProject = builder.AddSqlProject<Projects.aspire_error>(Constants.DatabaseDefinition)
  .WithReference(database);
```
Test Helper (The workaround is to adjust the apphost)
```csharp
var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.aspire_apphost>();
var app = appHost.Build();
await app.StartAsync();
await app.ResourceNotifications.WaitForResourceHealthyAsync(Constants.Database);
```

# Keycode (workaround the error)
```csharp
var errorDatabaseProject = builder.AddSqlProject(Constants.DatabaseDefinition)
  .WithDacpac("../sql/bin/aspire-error.dacpac")
  .WithReference(database);
```
