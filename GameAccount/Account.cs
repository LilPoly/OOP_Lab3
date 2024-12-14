using Lab3.DataBase;
using Lab3.Game;

namespace Lab3.GameAccount
{
    public class Account
    {
        public string UserName { get; set; }
        private int _currentRating = 1;
        public int Id { get; set; }
        
        private static int _nextId = 1;

        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value < 1 ? 1 : value;
        }

        protected List<PlayerHistory> Results { get; }
        public AccountType AccountType { get; set; }

        public Account(string username, AccountType accountType)
        {
            // Ініціалізуємо ID
            Id = _nextId++;
            UserName = username;
            AccountType = accountType;
            Results = new List<PlayerHistory>();
        }
        
        public virtual void WinGame(string typeGame, GameHistory game, Account player)
        {
            var beforeRating = CurrentRating;
            CurrentRating += game.Rating;
            Results.Add(new PlayerHistory(typeGame,  game.Rating, WinLose.Win, player, beforeRating, CurrentRating, 0)); 
        }

        public virtual void LoseGame(string typeGame, GameHistory game, Account player)
        {
            var beforeRating = CurrentRating;
            CurrentRating -= game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Rating, WinLose.Lose, player, beforeRating, CurrentRating, 0)); 
        }
    }
}
