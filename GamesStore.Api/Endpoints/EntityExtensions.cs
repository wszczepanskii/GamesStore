using GamesStore.Api.Dtos;
using GamesStore.Api.Entities;

namespace GamesStore.Api.Endpoints;

public static class EntityExtensions{
    public static GameDto AsDto(this Game game){
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }
}