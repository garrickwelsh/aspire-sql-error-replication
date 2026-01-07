using Aspire.Hosting.Testing;
using aspire_apphost;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.aspire_apphost>();

var app = appHost.Build();

await app.StartAsync();

await app.ResourceNotifications.WaitForResourceHealthyAsync(Constants.Database);
