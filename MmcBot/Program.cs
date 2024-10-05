using MmcBot.Data;
using MmcBot.Discord;
using MmcBot.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddData(builder.Configuration)
    .AddDiscord(builder.Configuration)
    .AddServices(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();