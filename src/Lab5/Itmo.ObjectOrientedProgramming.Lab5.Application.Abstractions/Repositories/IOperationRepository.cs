using Itmo.ObjectOrientedProgramming.Lab5.Application.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    void Create(Transaction transaction);
    IEnumerable<Transaction> GetAllOperationsByUser(long id);
}