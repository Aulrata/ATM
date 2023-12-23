using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

public interface ICustomerService
{
    UserResult Login(string? login, string? password);
    UserResult CreateAccount();
    UserResult PutMoneyIntoAccount(decimal money);
    UserResult WithdrawMoneyFromAccount(decimal money);
    IEnumerable<Transaction>? ShowTransactionsHistory();
    IEnumerable<Account>? ShowAllAccount();
    UserResult SetCurrentAccount(int accountId);
    decimal ShowBalance();
}