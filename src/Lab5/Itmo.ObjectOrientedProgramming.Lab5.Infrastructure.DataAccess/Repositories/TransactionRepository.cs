using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public void Create(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetAllTransactionsByUser(long id)
    {
        throw new NotImplementedException();
    }
}