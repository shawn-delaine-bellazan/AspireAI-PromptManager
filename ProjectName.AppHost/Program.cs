using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);


var sqlServer = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent)
                 .AddDatabase("ProjectNameDb");

var cache = builder.AddRedis("cache");


var dataService = builder.AddProject<Projects.ProjectName_DataService>("dataservice")
           .WithReference(sqlServer);

builder.AddProject<Projects.ProjectName_Web>("webfrontend")
    .WithReference(dataService);


builder.Build().Run();
