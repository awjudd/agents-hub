var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AgentsHub_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.AgentsHub_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(postgres)
    .WaitFor(postgres);

builder.Build().Run();
