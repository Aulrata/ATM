using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    void Create(Account account);
    IEnumerable<Account> GetAllAccountsByUser(int userId);
    Account? GetAccountById(int accountId);
    void UpdateBalance(int accountId, decimal newBalance);
}