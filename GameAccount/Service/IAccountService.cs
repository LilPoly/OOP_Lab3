using Lab3.GameAccount;

namespace Lab3.Account.Service
{
    public interface IAccountService
    {
        void CreateAccount(string username,  AccountType accountType);
        List<GameAccount.Account> GetAllAccounts();
        GameAccount.Account GetAccountById(int id);
        void UpdateAccount(GameAccount.Account account);
        void DeleteAccount(int accountId);
    }
}