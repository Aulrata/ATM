using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    void Create(Transaction transaction);
    IEnumerable<Transaction>? GetAllTransactionsByUser(int id);
}