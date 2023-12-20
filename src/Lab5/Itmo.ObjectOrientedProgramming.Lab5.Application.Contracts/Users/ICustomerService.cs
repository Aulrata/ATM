using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

public interface ICustomerService
{
    LoginResult Login(string login, string password);
    void CreateAccount();
    void PutMoneyIntoAccount(long accountId);
    void WithdrawMoneyFromAccount(long accountId);
    IEnumerable<Transaction> ShowTransactionsHistory();
    IEnumerable<Account> ShowAllAccount();
}