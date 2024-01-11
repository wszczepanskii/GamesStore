using GamesStore.Api.Endpoints;
using GamesStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepo, InMemGamesRepo>();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
