using GamesStore.Api.Entities;
using GamesStore.Api.Repositories;

namespace GamesStore.Api.Endpoints;

public static class GamesEndpoint{
    const string GetGameEndpointName = "GetGame";
   
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){
        InMemGamesRepo repo = new();
        
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", () => repo.GetAll);

            group.MapGet("/{id}", (int id) => {
            Game? game = repo.Get(id);

            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndpointName);

        group.MapPost("/", (Game game) => {
            repo.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) => {
            Game? existingGame = repo.Get(id);
            
            if(existingGame is null){
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ImageUri = updatedGame.ImageUri;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;

            repo.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            Game? game = repo.Get(id);
            
            if(game is not null){
                repo.Delete(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}