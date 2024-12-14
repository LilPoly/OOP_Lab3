namespace Lab3.Game.Service
{
}

namespace Lab3.Game.Service
{
    public interface IGameService
    {
        void CreateGame(int player1Id, int player2Id, string gameType, int rating);
        List<Game> GetAllGames();
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
        
        List<Game> GetGamesByPlayerId(int playerId);

    }
}

