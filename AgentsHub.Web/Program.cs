using AgentsHub.Core;
using AgentsHub.Core.Seeders;
using AgentsHub.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.ConfigureDatabaseService();
builder.AddNpgsqlDbContext<AgentsHubDbContext>(connectionName: "postgres");

builder.AddDefaultHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();


if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var databaseService = scope.ServiceProvider.GetRequiredService<AgentsHubDbContext>();
    
    databaseService.Database.EnsureCreated();
    databaseService.Database.Migrate();
    DefaultDatabaseSeeder.SeedAsync(databaseService).Wait();
}

app.Run();