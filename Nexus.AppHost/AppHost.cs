var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Nexus_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Nexus_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
