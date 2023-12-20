using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void Create(Account account)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllAccountsByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Account? GetAccountById(long accountId)
    {
        throw new NotImplementedException();
    }
}