using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    public void Create(Account account)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllAccountsByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Account GetAccountById(long accountId)
    {
        throw new NotImplementedException();
    }
}