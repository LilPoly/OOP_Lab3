using Lab3.Account.Service;
using Lab3.Account;
using System;
using Lab3.DataBase;
using Lab3.Game.Service;
using Lab3.GameAccount;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new DbContext(); 

        var accountRepository = new AccountRepository(dbContext);
        var gameRepository = new GameRepository(dbContext); 

        var gameService = new GameService(gameRepository, accountRepository); 
        var accountService = new AccountService(accountRepository); 

        accountService.CreateAccount("Steve", AccountType.Premium); 
        accountService.CreateAccount("Jack", AccountType.Standard);
        accountService.CreateAccount("Tom", AccountType.Vip);
     
        var allAccounts = accountService.GetAllAccounts();
        foreach (var account in allAccounts)
        {
            Console.WriteLine($"ID: {account.Id}, Username: {account.UserName}, Account Type: {account.AccountType}");
        }

        gameService.CreateGame(1, 3, "Classic", 10);
        gameService.CreateGame(2, 1, "Training", 0);
        gameService.CreateGame(3, 1, "Classic", 10);

        gameService.GetGamesByPlayerId(2);
        gameService.GetAllGames();
    }
}

