using lab3_15;
using lab3_15.service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<TCPServer>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<FlightService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}



await host.RunAsync();