using Lab3.Game;
using Lab3.GameAccount;

namespace Lab3.DataBase;

public class DbContext
{
    public List<GameAccount.Account> Accounts { get; }
    public List<Game.Game> Games { get; }

    public DbContext()
    {
        Accounts = new List<GameAccount.Account>();
        Games = new List<Game.Game>();
    }
}
