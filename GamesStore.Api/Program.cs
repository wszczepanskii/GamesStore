using GamesStore.Api.Entities;

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

app.MapGet("/games", () => "Hello Worlss2sdasss!");

app.Run();
