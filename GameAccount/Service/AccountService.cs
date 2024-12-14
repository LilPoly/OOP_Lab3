using Lab3.Account.Service;
using Lab3.DataBase;
using Lab3.GameAccount;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private static int _nextId = 1;
    
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void CreateAccount(string username, AccountType accountType)
    {
        Account account;
        switch (accountType)
        {
            case AccountType.Premium:
                account = new PremiumAccount(username);
                break;
            case AccountType.Vip:
                account = new VipAccount(username);
                break;
            case AccountType.Standard:
            default:
                account = new Account(username, AccountType.Standard);
                break;
        }

        _accountRepository.CreateAccount(account);  
        Console.WriteLine($"Account created: {account.UserName}, Type: {account.AccountType}");
    }


    public List<Account> GetAllAccounts()
    {
        var accounts = _accountRepository.GetAllAccounts();
        Console.WriteLine($"Retrieved {accounts.Count} accounts.");
        return accounts;
    }

    public Account GetAccountById(int id)
    {
        var account = _accountRepository.ReadAccountById(id);
        if (account != null)
        {
            Console.WriteLine($"Account found: {account.UserName}");
        }
        else
        {
            Console.WriteLine($"No account found with ID: {id}");
        }
        return account;
    }

    public void UpdateAccount(Account account)
    {
        _accountRepository.UpdateAccount(account);
        Console.WriteLine($"Account updated: {account.UserName}");
    }

    public void DeleteAccount(int accountId)
    {
        _accountRepository.DeleteAccount(accountId);
        Console.WriteLine($"Account with ID {accountId} deleted.");
    }
}