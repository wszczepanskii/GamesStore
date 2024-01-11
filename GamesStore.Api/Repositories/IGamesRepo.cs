using GamesStore.Api.Entities;

namespace GamesStore.Api.Repositories;

public interface IGamesRepo
{
    void Create(Game game);
    void Delete(int id);
    Game? Get(int id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);
}
