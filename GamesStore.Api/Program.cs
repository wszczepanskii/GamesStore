using GamesStore.Api.Entities;

const string GetGameEndpointName = "GetGame";

List<Game> games = new (){
    new Game(){
        Id = 1,
        Name = "Minecraft",
        Genre = "Survival",
        Price = 19.99M,
        ReleaseDate = new DateTime(2009, 10, 12),
        ImageUri = "https://placehold.co/100",
    },
    new Game(){
        Id = 2,
        Name = "Fortnite",
        Genre = "Battle royale",
        Price = 29.99M,
        ReleaseDate = new DateTime(2019, 1, 21),
        ImageUri = "https://placehold.co/100",
    },
    new Game(){
        Id = 3,
        Name = "CS:GO",
        Genre = "FPS",
        Price = 39.99M,
        ReleaseDate = new DateTime(2014, 5, 7),
        ImageUri = "https://placehold.co/100",
    },
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games").WithParameterValidation();

group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) => {
    Game? game = games.Find(game => game.Id == id);
    
    if(game is null){
        return Results.NotFound();
    }
    return Results.Ok(game); 

}).WithName(GetGameEndpointName);

group.MapPost("/", (Game game) => {
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

group.MapPut("/{id}", (int id, Game updatedGame) => {
    Game? existingGame = games.Find(game => game.Id == id);
    
    if(existingGame is null){
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ImageUri = updatedGame.ImageUri;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) => {
    Game? game = games.Find(game => game.Id == id);
    
    if(game is not null){
        games.Remove(game);
    }

    

    return Results.NoContent();
});

app.Run();
