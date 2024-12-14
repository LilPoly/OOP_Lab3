namespace Lab3.Game.Repo;

public interface IGameRepository
{
    void CreateGame(Game game);  
    List<Game> GetAllGames();
    Game GetGameById(int id);
    void UpdateGame(Game game);
    void DeleteGame(int id);
}

