using GamesStore.Api.Entities;

namespace GamesStore.Api.Repositories;

public class InMemGamesRepo{
    private readonly List<Game> games = new (){
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

    public IEnumerable<Game> GetAll(){
        return games;
    }

    public Game? Get(int id){
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game){
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame){
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id){
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}